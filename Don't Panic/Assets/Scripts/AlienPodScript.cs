using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienPodScript : MonoBehaviour {

	public Canvas hudCanvas;
	public Canvas decisionCanvas;

	public Canvas sliderCanvas;
	public Slider slider;

	public GameObject alien;

	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;
	private bool alienConvoFlag = false;
	private bool yesBtnFlag;
	private float sceneStartTime;
	private Color alienTextColor;

	// Use this for initialization
	void Start () {
		slider.maxValue = hoverTime;
		sliderCanvas.gameObject.SetActive (false);

		sceneStartTime = Time.time;
		alienTextColor = new Color (0, 1, 0, 1);

		decisionCanvas.gameObject.SetActive (false);

		if (!StaticValues.CheckedAlienPod) {
			StaticValues.CurrentSubScene = "AP_1";
		} else {
			Destroy (alien);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (pointerFlag) {
			//Sets the progress slider value
			float sliderValue = Time.time - enterTime;
			slider.value = sliderValue;

			if ((Time.time - enterTime) > hoverTime) {
				if (yesBtnFlag) {
					YesBtn ();
				} else {
					NoBtn ();
				}

				pointerFlag = false;
			}
		}

		switch (StaticValues.CurrentSubScene) {
		case "AP_1":
			if (Time.time - sceneStartTime > 0.5f && Time.time - sceneStartTime < 0.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienPodLines[0];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			}
			if (Time.time - sceneStartTime > 3.5f && Time.time - sceneStartTime < 3.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienLines[0];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (4f,alienTextColor);
			}
			if (Time.time - sceneStartTime > 7.5f && Time.time - sceneStartTime < 7.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienPodLines[1];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (4f);
			}
			if (Time.time - sceneStartTime > 11.5f && Time.time - sceneStartTime < 11.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienLines[1];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (4f,alienTextColor);
			}
			if (Time.time - sceneStartTime > 15.5f && Time.time - sceneStartTime < 15.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienPodLines[2];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (4f);
			}
			if (Time.time - sceneStartTime > 19.5f && Time.time - sceneStartTime < 19.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienLines[2];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (5f,alienTextColor);
			}
			if (Time.time - sceneStartTime > 24.5f && Time.time - sceneStartTime < 24.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienPodLines[3];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (4f);
			}
			if (Time.time - sceneStartTime > 28.5f && Time.time - sceneStartTime < 28.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienLines[3];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (4f,alienTextColor);
			}
			if (Time.time - sceneStartTime > 32.5f && Time.time - sceneStartTime < 32.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienLines[4];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (4f,alienTextColor);
			}
			if (Time.time - sceneStartTime > 36.5f && Time.time - sceneStartTime < 36.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienPodLines[4];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (4f);
			}
			if (Time.time - sceneStartTime > 40.5f && Time.time - sceneStartTime < 40.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienLines[6];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (4f,alienTextColor);
			}
			if (Time.time - sceneStartTime > 43.5f && Time.time - sceneStartTime < 43.7f) {
				alienConvoFlag = true;
				StaticValues.CurrentSubScene = " ";
			}
			break;
		case "AP_2":
			if (Time.time - sceneStartTime > 0.5f && Time.time - sceneStartTime < 0.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienPodLines[6];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			}
			if (Time.time - sceneStartTime > 3.5f && Time.time - sceneStartTime < 3.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienLines[7];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (4f,alienTextColor);
				StaticValues.CurrentSubScene = " ";
				StaticValues.CheckedAlienPod = true;
			}
			break;
		case "AP_3":
			if (Time.time - sceneStartTime > 0.5f && Time.time - sceneStartTime < 0.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienPodLines[7];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			}
			if (Time.time - sceneStartTime > 3.5f && Time.time - sceneStartTime < 3.7f) {
				StaticValues.CurrentHUDMessage = StoryText.AlienLines[8];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (4f,alienTextColor);
				StaticValues.CurrentSubScene = " ";
				StaticValues.CheckedAlienPod = true;
			}
			break;
		default:
			break;
		}

		if (alienConvoFlag) {
			decisionCanvas.gameObject.SetActive (true);
			alienConvoFlag = false;
		}
	}

	public void YesBtn() {
		Debug.Log ("Let him go");
		decisionCanvas.gameObject.SetActive (false);
		sliderCanvas.gameObject.SetActive (false);

		sceneStartTime = Time.time;
		StaticValues.CurrentSubScene = "AP_2";

	}

	public void EnterYesBtn() {
		yesBtnFlag = true;
		PointerEnter ();
	}

	public void ExitYesBtn() {
		PointerExit ();
	}

	public void NoBtn() {
		Debug.Log ("Kill him");
		decisionCanvas.gameObject.SetActive (false);
		sliderCanvas.gameObject.SetActive (false);

		sceneStartTime = Time.time;
		StaticValues.CurrentSubScene = "AP_3";
	}

	public void EnterNoBtn() {
		yesBtnFlag = false;
		PointerEnter ();
	}

	public void ExitNoBtn() {
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
