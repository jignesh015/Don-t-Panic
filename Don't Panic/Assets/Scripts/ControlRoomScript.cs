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

	public List<GameObject> collectibles;

	public AudioSource bigScreenAudioSource;
	public AudioClip dontPanicAudioClip;
	public AudioClip computerClickClip;

	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;
	private AudioSource controlRoomAudioSource;

	// Use this for initialization
	void Start () {
		slider.maxValue = hoverTime;
		sliderCanvas.gameObject.SetActive (false);

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
		}

		if (!StaticValues.DontPanicFlag) {
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
	}

	public void SwitchOffWarning() {
		computerScreen.GetComponent<MeshRenderer> ().material = warningSwitchedOffMat;
		bigScreen.GetComponent<MeshRenderer> ().material = bigScreenMat;

		Destroy (computerScreen.GetComponent<BoxCollider> ());

		bigScreenAudioSource.Stop ();

		controlRoomAudioSource.clip = computerClickClip;
		controlRoomAudioSource.Play ();

		StaticValues.DontPanicFlag = false;

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
