using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceShuttleScript : MonoBehaviour {

	public Canvas sliderCanvas;
	public Slider slider;
	public Canvas hudCanvas;
	public GameObject spaceShuttle;
	public GameObject messageIcon;
	public GameObject messageBg;
	public GameObject closeBtn;
	public Text messageText;
	public Canvas decisionCanvas;
	public GameObject doorConsole;
	public AudioSource clickAudioSource;
	public Animator fadeOutAnimator;
	public bool toggleKilledAlien = false;

	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;
	private string highlightedBtn;
	private float sceneStartTime;

	// Use this for initialization
	void Start () {
		slider.maxValue = hoverTime;
		sliderCanvas.gameObject.SetActive (false);

		decisionCanvas.gameObject.SetActive (false);

		sceneStartTime = Time.time;

		messageText.text = StoryText.ConsoleMessageText [0];

		if (toggleKilledAlien) {
			StaticValues.KilledAlien = true;
		}

		if (!StaticValues.KilledAlien) {
			StaticValues.CurrentSubScene = "SP_1";
			Destroy (spaceShuttle);
		} else {
			StaticValues.CurrentSubScene = "SP_2";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (pointerFlag) {
			//Sets the progress slider value
			float sliderValue = Time.time - enterTime;
			slider.value = sliderValue;

			if ((Time.time - enterTime) > hoverTime) {
				switch (highlightedBtn) {
				case "icon":
					ReadMessage ();
					break;
				case "close":
					CloseMessage ();
					break;
				case "choice_1":
					Choice_1 ();
					break;
				case "choice_2":
					Choice_2 ();
					break;
				default:
					break;
				}
				pointerFlag = false;
			}
		}

		//Story text
		switch (StaticValues.CurrentSubScene) {
		case "SP_1":
			if (Time.time - sceneStartTime > 1.0f && Time.time - sceneStartTime < 1.2f) {
				StaticValues.CurrentHUDMessage = StoryText.SpaceShuttlePodLines [1];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
				StaticValues.CurrentObjective = StoryText.Objectives [16];
				StaticValues.CurrentSubScene = " ";
			}
			break;
		case "SP_2":
			if (Time.time - sceneStartTime > 1.0f && Time.time - sceneStartTime < 1.2f) {
				StaticValues.CurrentHUDMessage = StoryText.SpaceShuttlePodLines [0];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			}
			if (Time.time - sceneStartTime > 4.0f && Time.time - sceneStartTime < 4.2f) {
				StaticValues.CurrentHUDMessage = StoryText.SpaceShuttlePodLines [1];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
				StaticValues.CurrentObjective = StoryText.Objectives [16];
				StaticValues.CurrentSubScene = " ";
			}
			break;
		case "SP_3":
			if (Time.time - sceneStartTime > 1.0f && Time.time - sceneStartTime < 1.2f) {
				StaticValues.CurrentHUDMessage = StoryText.SpaceShuttlePodLines [2];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			}
			if (Time.time - sceneStartTime > 4.0f && Time.time - sceneStartTime < 4.2f) {
				StaticValues.CurrentHUDMessage = StoryText.SpaceShuttlePodLines [3];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
				StaticValues.CurrentSubScene = "SP_5";
			}
			break;
		case "SP_4":
			if (Time.time - sceneStartTime > 1.0f && Time.time - sceneStartTime < 1.2f) {
				StaticValues.CurrentHUDMessage = StoryText.SpaceShuttlePodLines [4];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			}
			if (Time.time - sceneStartTime > 4.0f && Time.time - sceneStartTime < 4.2f) {
				StaticValues.CurrentHUDMessage = StoryText.SpaceShuttlePodLines [6];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
				StaticValues.CurrentSubScene = "SP_5";
			}
			break;
		case "SP_5":
			if (Time.time - sceneStartTime > 7.0f && Time.time - sceneStartTime < 7.2f) {
				StaticValues.CurrentHUDMessage = StoryText.SpaceShuttlePodLines [7];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			}
			if (Time.time - sceneStartTime > 10.0f && Time.time - sceneStartTime < 10.2f) {
				StaticValues.CurrentHUDMessage = StoryText.SpaceShuttlePodLines [8];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (5f);
			}
			if (Time.time - sceneStartTime > 16.0f && Time.time - sceneStartTime < 16.2f) {
				StaticValues.CurrentHUDMessage = StoryText.SpaceShuttlePodLines [9];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (5f, new Color(250,0,0));
			}
			if (Time.time - sceneStartTime > 17.0f && Time.time - sceneStartTime < 17.2f) {
				fadeOutAnimator.SetBool ("FadeOut", true);
			}
			if (Time.time - sceneStartTime > 20.0f && Time.time - sceneStartTime < 21.2f) {
				SceneManager.LoadScene ("End_credits");
			}
			break;
		default:
			break;
		}
	}

	public void ReadMessage() {
		doorConsole.GetComponent<BoxCollider> ().enabled = false;
		StaticValues.CurrentObjective = StoryText.Objectives [0];
		clickAudioSource.Play ();
		messageIcon.SetActive (false);
		messageBg.SetActive (true);
		closeBtn.SetActive (true);
		PointerExit ();
	}

	public void EnterMessage() {
		highlightedBtn = "icon";
		PointerEnter ();
	}

	public void ExitMessage() {
		PointerExit ();
	}

	public void CloseMessage() {
		messageBg.SetActive (false);
		closeBtn.SetActive (false);
		if (StaticValues.KilledAlien) {
			decisionCanvas.gameObject.SetActive (true);
			decisionCanvas.gameObject.GetComponent<AudioSource> ().Play ();
		} else {
			sceneStartTime = Time.time;
			StaticValues.CurrentSubScene = "SP_3";
		}
		PointerExit ();
	}

	public void EnterClose() {
		highlightedBtn = "close";
		PointerEnter ();
	}

	public void ExitClose() {
		PointerExit ();
	}

	public void Choice_1() {
		StaticValues.ChoseToWait = true;
		clickAudioSource.Play ();
		decisionCanvas.gameObject.SetActive (false);
		sceneStartTime = Time.time;
		StaticValues.CurrentSubScene = "SP_3";
		PointerExit ();
	}

	public void EnterChoice_1() {
		highlightedBtn = "choice_1";
		PointerEnter ();
	}

	public void ExitChoice_1() {
		PointerExit ();
	}

	public void Choice_2() {
		StaticValues.ChoseToWait = false;
		clickAudioSource.Play ();
		decisionCanvas.gameObject.SetActive (false);
		sceneStartTime = Time.time;
		StaticValues.CurrentSubScene = "SP_4";
		PointerExit ();
	}

	public void EnterChoice_2() {
		highlightedBtn = "choice_2";
		PointerEnter ();
	}

	public void ExitChoice_2() {
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
