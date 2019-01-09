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

	public GameObject book;

	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;
	private AudioSource controlRoomAudioSource;
	private float sceneStartTime;
	private bool bookFlag = false;
	private bool openBookFlag = false;
	private BoxCollider bookBoxCollider;

	// Use this for initialization
	void Start () {
		bgAudioSource.time = 36.0f;
		bookBoxCollider = book.GetComponent<BoxCollider> ();

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
				if (bookFlag) {
					CheckoutBook ();
				} else {
					SwitchOffWarning ();
				}

				pointerFlag = false;
			}
		}

		//Story text
		if (StaticValues.DontPanicFlag) {
			StaticValues.CurrentSubScene = "CR_0";
		}

		switch(StaticValues.CurrentSubScene)
		{
		case "CR_0":
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
				StaticValues.CurrentSubScene = " ";
			}
			break;
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
		case "CR_2":
			sceneStartTime = Time.time;

			StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines [7];
			hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			StaticValues.CurrentObjective = StoryText.Objectives [7];
			StaticValues.CurrentSubScene = "CR_3";

			break;
		case "CR_3":
			if (Time.time - sceneStartTime > 3.0f && Time.time - sceneStartTime < 3.2f) {
				StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines [8];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
				StaticValues.CurrentSubScene = " ";
			}
			break;
		case "CR_4":
			StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines [9];
			hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (2f);
			if (Time.time - sceneStartTime > 2.0f && Time.time - sceneStartTime < 2.2f) {
				StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines [11];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
				StaticValues.CurrentSubScene = " ";
				bookBoxCollider.enabled = true;
			}
			break;
		case "CR_5":
			StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines [12];
			hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			if (Time.time - sceneStartTime > 3.0f && Time.time - sceneStartTime < 3.2f) {
				StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines [13];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
				StaticValues.CurrentSubScene = " ";
				openBookFlag = true;
				bookBoxCollider.enabled = true;
			}
			break;
		case "CR_6":
			if (Time.time - sceneStartTime > 0.5f && Time.time - sceneStartTime < 0.7f) {
				StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines [14];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			}
			if (Time.time - sceneStartTime > 3.0f && Time.time - sceneStartTime < 3.2f) {
				StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines [16];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (10f);
			}
			if (Time.time - sceneStartTime > 10.0f && Time.time - sceneStartTime < 10.2f) {
				StaticValues.CurrentHUDMessage = StoryText.ControlRoomLines [17];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (4f);
				StaticValues.CurrentObjective = StoryText.Objectives [8];
				StaticValues.CheckedPassword = true;
				StaticValues.CurrentSubScene = " ";
				bookBoxCollider.enabled = true;
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

	public void CheckoutBook() {
		if (!StaticValues.CheckedCaptainDoor) {
			StaticValues.CurrentSubScene = "CR_4";
			sceneStartTime = Time.time;
			bookBoxCollider.enabled = false;
		} else {
			if (!openBookFlag) {
				StaticValues.CurrentSubScene = "CR_5";
				sceneStartTime = Time.time;
				bookBoxCollider.enabled = false;
			} else {
				StaticValues.CurrentSubScene = "CR_6";
				sceneStartTime = Time.time;
				bookBoxCollider.enabled = false;
			}
		}
	}

	public void EnterBook() {
		bookFlag = true;
		PointerEnter ();
	}

	public void ExitBook() {
		bookFlag = false;
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
