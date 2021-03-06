﻿/**
* Copyright 2015 IBM Corp. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/
#pragma warning disable 0649

using UnityEngine;
using System.Collections;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.DataTypes;
using System.Collections.Generic;
using UnityEngine.UI;

public class ExampleStreaming : MonoBehaviour
{
    #region PLEASE SET THESE VARIABLES IN THE INSPECTOR
    [Space(10)]
    [Tooltip("The service URL (optional). This defaults to \"https://stream.watsonplatform.net/speech-to-text/api\"")]
    [SerializeField]
    private string _serviceUrl;
    [Tooltip("Text field to display the results of streaming.")]
    public Text ResultsField;
    [Header("IAM Authentication")]
    [Tooltip("The IAM apikey.")]
    [SerializeField]
    private string _iamApikey;

    [Header("Parameters")]
    // https://www.ibm.com/watson/developercloud/speech-to-text/api/v1/curl.html?curl#get-model
    [Tooltip("The Model to use. This defaults to en-US_BroadbandModel")]
    [SerializeField]
    private string _recognizeModel;

	public AudioClip passIncorrect;
	public AudioClip passCorrect;

	public GameObject captainDoor;

	public Canvas sliderCanvas;
	public Slider slider;

	public GameObject doorWaypoint;
	public GameObject cameraObj;

	public bool skipPasswordCheck;
    #endregion


    private int _recordingRoutine = 0;
    private string _microphoneID = null;
    private AudioClip _recording = null;
    private int _recordingBufferSize = 1;
    private int _recordingHZ = 22050;
	private AudioSource _passAudioSource;
	private bool _pointerFlag = false;
	private float _enterTime;
	private float _hoverTime = 1.5f;
	private bool _startedRecording = false;

    private SpeechToText _service;

    void Start()
    {
        LogSystem.InstallDefaultReactors();
        Runnable.Run(CreateService());

		_passAudioSource = gameObject.GetComponent<AudioSource> ();

		slider.maxValue = _hoverTime;
		sliderCanvas.gameObject.SetActive (false);
    }

	void Update () {
		if (_pointerFlag) {
			//Sets the progress slider value
			float sliderValue = Time.time - _enterTime;
			slider.value = sliderValue;

			if ((Time.time - _enterTime) > _hoverTime) {
				BtnRecord ();
				_pointerFlag = false;
			}
		}

		if (_startedRecording) {
			if (cameraObj.transform.position != doorWaypoint.transform.position) {
				StopRecording ();
				ResultsField.text = "Password \n needed";
				_startedRecording = false; 
			}
		}
	}

    private IEnumerator CreateService()
    {
        if (string.IsNullOrEmpty(_iamApikey))
        {
            throw new WatsonException("Plesae provide IAM ApiKey for the service.");
        }

        //  Create credential and instantiate service
        Credentials credentials = null;

        //  Authenticate using iamApikey
        TokenOptions tokenOptions = new TokenOptions()
        {
            IamApiKey = _iamApikey
        };

        credentials = new Credentials(tokenOptions, _serviceUrl);

        //  Wait for tokendata
        while (!credentials.HasIamTokenData())
            yield return null;

        _service = new SpeechToText(credentials);
        _service.StreamMultipart = true;

        //Active = true;
        //StartRecording();
    }

    public bool Active
    {
        get { return _service.IsListening; }
        set
        {
            if (value && !_service.IsListening)
            {
                _service.RecognizeModel = (string.IsNullOrEmpty(_recognizeModel) ? "en-US_BroadbandModel" : _recognizeModel);
                _service.DetectSilence = true;
                _service.EnableWordConfidence = true;
                _service.EnableTimestamps = true;
                _service.SilenceThreshold = 0.01f;
                _service.MaxAlternatives = 0;
                _service.EnableInterimResults = true;
                _service.OnError = OnError;
                _service.InactivityTimeout = -1;
                _service.ProfanityFilter = false;
                _service.SmartFormatting = true;
                _service.SpeakerLabels = false;
                _service.WordAlternativesThreshold = null;
                _service.StartListening(OnRecognize, OnRecognizeSpeaker);
            }
            else if (!value && _service.IsListening)
            {
                _service.StopListening();
            }
        }
    }

	public void BtnRecord() {
		if (!skipPasswordCheck) {
			if (!StaticValues.CheckedPassword) {
				StaticValues.CheckedCaptainDoor = true;
				StaticValues.CurrentSubScene = "CR_2";
			}

			_passAudioSource.clip = passCorrect;
			_passAudioSource.Play ();
			Active = true;
			StartRecording ();
			_startedRecording = true;
			ResultsField.text = "Speak \n password";
		} else {
			captainDoor.GetComponent<OpenDoor>().Open_Door("Captain_pod");
		}

	}

	public void Enter() {
		sliderCanvas.gameObject.SetActive (true);
		_pointerFlag = true;
		_enterTime = Time.time;
	}

	public void Exit() {
		_pointerFlag = false;
		sliderCanvas.gameObject.SetActive (false);
		//Reset progress slider value
		slider.value = 0.0f;
	}

    private void StartRecording()
    {
        if (_recordingRoutine == 0)
        {
            UnityObjectUtil.StartDestroyQueue();
            _recordingRoutine = Runnable.Run(RecordingHandler());
        }
    }

    private void StopRecording()
    {
		//Debug.Log ("Recording stopped");
        if (_recordingRoutine != 0)
        {
            Microphone.End(_microphoneID);
            Runnable.Stop(_recordingRoutine);
            _recordingRoutine = 0;
        }
    }

    private void OnError(string error)
    {
        Active = false;

        Log.Debug("ExampleStreaming.OnError()", "Error! {0}", error);
    }

    private IEnumerator RecordingHandler()
    {
        //Log.Debug("ExampleStreaming.RecordingHandler()", "devices: {0}", Microphone.devices);
        _recording = Microphone.Start(_microphoneID, true, _recordingBufferSize, _recordingHZ);
        yield return null;      // let _recordingRoutine get set..

        if (_recording == null)
        {
            StopRecording();
            yield break;
        }

        bool bFirstBlock = true;
        int midPoint = _recording.samples / 2;
        float[] samples = null;

        while (_recordingRoutine != 0 && _recording != null)
        {
            int writePos = Microphone.GetPosition(_microphoneID);
            if (writePos > _recording.samples || !Microphone.IsRecording(_microphoneID))
            {
                //Log.Error("ExampleStreaming.RecordingHandler()", "Microphone disconnected.");

                StopRecording();
                yield break;
            }

            if ((bFirstBlock && writePos >= midPoint)
              || (!bFirstBlock && writePos < midPoint))
            {
                // front block is recorded, make a RecordClip and pass it onto our callback.
                samples = new float[midPoint];
                _recording.GetData(samples, bFirstBlock ? 0 : midPoint);

                AudioData record = new AudioData();
				record.MaxLevel = Mathf.Max(Mathf.Abs(Mathf.Min(samples)), Mathf.Max(samples));
                record.Clip = AudioClip.Create("Recording", midPoint, _recording.channels, _recordingHZ, false);
                record.Clip.SetData(samples, 0);

                _service.OnListen(record);

                bFirstBlock = !bFirstBlock;
            }
            else
            {
                // calculate the number of samples remaining until we ready for a block of audio, 
                // and wait that amount of time it will take to record.
                int remaining = bFirstBlock ? (midPoint - writePos) : (_recording.samples - writePos);
                float timeRemaining = (float)remaining / (float)_recordingHZ;

                yield return new WaitForSeconds(timeRemaining);
            }

        }

        yield break;
    }

    private void OnRecognize(SpeechRecognitionEvent result, Dictionary<string, object> customData)
    {
        if (result != null && result.results.Length > 0)
        {
            foreach (var res in result.results)
            {
                foreach (var alt in res.alternatives)
                {
					Debug.Log (alt.transcript.Trim ().ToLower ());
					if (StaticValues.Keywords.Contains(alt.transcript.Trim().ToLower())) {
						ResultsField.text = "Password \n correct";
						_passAudioSource.clip = passCorrect;
						_passAudioSource.Play ();
						StopRecording ();
						captainDoor.GetComponent<OpenDoor>().Open_Door("Captain_pod");
					} else {
						_passAudioSource.clip = passIncorrect;
						_passAudioSource.Play ();
						ResultsField.text = "Password \n incorrect \n Try again" ;
					}
                }

//                if (res.keywords_result != null && res.keywords_result.keyword != null)
//                {
//                    foreach (var keyword in res.keywords_result.keyword)
//                    {
//                        Log.Debug("ExampleStreaming.OnRecognize()", "keyword: {0}, confidence: {1}, start time: {2}, end time: {3}", keyword.normalized_text, keyword.confidence, keyword.start_time, keyword.end_time);
//                    }
//                }
//
//                if (res.word_alternatives != null)
//                {
//                    foreach (var wordAlternative in res.word_alternatives)
//                    {
//                        Log.Debug("ExampleStreaming.OnRecognize()", "Word alternatives found. Start time: {0} | EndTime: {1}", wordAlternative.start_time, wordAlternative.end_time);
//                        foreach(var alternative in wordAlternative.alternatives)
//                            Log.Debug("ExampleStreaming.OnRecognize()", "\t word: {0} | confidence: {1}", alternative.word, alternative.confidence);
//                    }
//                }
            }
        }
    }

    private void OnRecognizeSpeaker(SpeakerRecognitionEvent result, Dictionary<string, object> customData)
    {
        if (result != null)
        {
            foreach (SpeakerLabelsResult labelResult in result.speaker_labels)
            {
                Log.Debug("ExampleStreaming.OnRecognize()", string.Format("speaker result: {0} | confidence: {3} | from: {1} | to: {2}", labelResult.speaker, labelResult.from, labelResult.to, labelResult.confidence));
            }
        }
    }
}
