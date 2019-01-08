using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlRoomScript : MonoBehaviour {

	public GameObject computerScreen;
	public GameObject bigScreen;
	public Material warningSwitchedOffMat;
	public Material bigScreenMat;

	public Canvas sliderCanvas;
	public Slider slider;
	public Canvas hudCanvas;

	public List<GameObject> collectibles;
	public AudioSource bigScreenAudioSource;
	public AudioClip dontPanicAudioClip;
	public AudioClip computerClickClip;
	public AudioSource bgAudioSource;

	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;
	private AudioSource controlRoomAudioSource;
	private float sceneStartTime;

	// Use this for initialization
	void Start () {
		bgAudioSource.time = 36.0f;

		slider.maxValue = hoverTime;
		sliderCanvas.gameObject.SetActive (false);

		sceneStartTime = Time.time;

		//Destroy already collected artworks on scene load
		if (StaticValues.CollectibleList.Count > 0) {
			if (StaticValues.CollectibleList.Contains ("cr_art_0")) {
				Destroy (collectibles [0]);
			}
			if (StaticValues.CollectibleList.Contains ("cr_art_1")) {
				Destroy (collectibles [1]);
			}
			if (StaticValues.CollectibleList.Contains ("cr_art_2")) {
				Destroy (collectibles [2]);
			}
		}

		if (StaticValues.DontPanicFlag) {
			controlRoomAudioSource = gameObject.GetComponent<AudioSource> ();

			bigScreenAudioSource.clip = dontPanicAudioClip;
			bigScreenAudioSource.loop = true;
			bigScreenAudioSource.Play ();
		}else {
			computerScreen.GetComponent<MeshRenderer> ().material = warningSwitchedOffMat;
			bigScreen.GetComponent<MeshRenderer> ().material = bigScreenMat;
			Destroy (computerScreen.GetComponent<BoxCollider> ());
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		if (pointerFlag) {
			//Sets the progress slider value
			float sliderValue = Time.time - enterTime;
			slider.value = sliderValue;

			if ((Time.time - enterTime) > hoverTime) {
				SwitchOffWarning ();
				pointerFlag = false;
			}
		}

		//Story text
		if (StaticValues.DontPanicFlag) {
			if (Time.time - sceneStartTime > 1.0f && Time.time - sceneStartTime < 1.2f) {
				StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines[0];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
				StaticValues.CurrentObjective = StoryText.Objectives [2];
			}
			if (Time.time - sceneStartTime > 4.0f && Time.time - sceneStartTime < 4.2f) {
				StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines[1];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			}
			if (Time.time - sceneStartTime > 7.0f && Time.time - sceneStartTime < 7.2f) {
				StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines[2];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			}
		}

		switch(StaticValues.CurrentSubScene)
		{
		case "CR_1":
			if (Time.time - sceneStartTime > 4.0f && Time.time - sceneStartTime < 4.2f) {
				StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines [4];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			}
			if (Time.time - sceneStartTime > 7.0f && Time.time - sceneStartTime < 7.2f) {
				StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines [6];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
				StaticValues.CurrentSubScene = " ";
			}
			break;
		default:
			break;
		}
	}

	public void SwitchOffWarning() {
		computerScreen.GetComponent<MeshRenderer> ().material = warningSwitchedOffMat;
		bigScreen.GetComponent<MeshRenderer> ().material = bigScreenMat;

		Destroy (computerScreen.GetComponent<BoxCollider> ());

		bigScreenAudioSource.Stop ();

		controlRoomAudioSource.clip = computerClickClip;
		controlRoomAudioSource.Play ();

		StaticValues.DontPanicFlag = false;
		StaticValues.CurrentSubScene = "CR_1";
		sceneStartTime = Time.time;

		//Story text
		StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines[3];
		hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3.5f);
		StaticValues.CurrentObjective = StoryText.Objectives [3];
	}

	public void enterComputerScreen() {
		PointerEnter ();
	}

	public void exitComputerScreen() {
		PointerExit ();
	}

	private void PointerEnter() {
		sliderCanvas.gameObject.SetActive (true);
		pointerFlag = true;
		enterTime = Time.time;
	}

	private void PointerExit() {
		pointerFlag = false;
		sliderCanvas.gameObject.SetActive (false);
		//Reset progress slider value
		slider.value = 0.0f;
	}
}
