using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LieutenantPodScript : MonoBehaviour {

	public List<GameObject> collectibles;

	public Canvas sliderCanvas;
	public Slider slider;

	public Canvas hudCanvas;
	public GameObject gun;
	public AudioClip collectGunAudio;

	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;
	private float sceneStartTime;
	private bool lieutenantLogFlag = true;
	private AudioSource collectGunAudioSource;

	// Use this for initialization
	void Start () {
		slider.maxValue = hoverTime;
		sliderCanvas.gameObject.SetActive (false);

		sceneStartTime = Time.time;
		collectGunAudioSource = gameObject.GetComponent<AudioSource> ();
		collectGunAudioSource.playOnAwake = false;

		if (StaticValues.CollectibleList.Count > 0) {
			if (StaticValues.CollectibleList.Contains ("lt_art_0")) {
				Destroy (collectibles [0]);
			}
		}

		if (StaticValues.IsGunCollected) {
			Destroy (gun);
		}

		if (!StaticValues.CheckedLieutenantLog) {
			StaticValues.CurrentSubScene = "LP_1";
		} else {
			lieutenantLogFlag = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (pointerFlag) {
			//Sets the progress slider value
			float sliderValue = Time.time - enterTime;
			slider.value = sliderValue;

			if ((Time.time - enterTime) > hoverTime) {
				CollectGun ();
				pointerFlag = false;
			}
		}

		if (StaticValues.CheckedLieutenantLog && lieutenantLogFlag) {
			lieutenantLogFlag = false;
			StaticValues.CurrentSubScene = "LP_2";
			sceneStartTime = Time.time;
		}

		//Story text
		switch(StaticValues.CurrentSubScene)
		{
		case "LP_1":
			if (Time.time - sceneStartTime > 1.5f && Time.time - sceneStartTime < 1.7f) {
				StaticValues.CurrentHUDMessage = StoryText.LieutenantPodLines [0];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (2f);
			}
			if (Time.time - sceneStartTime > 3.0f && Time.time - sceneStartTime < 3.2f) {
				StaticValues.CurrentHUDMessage = StoryText.LieutenantPodLines [1];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (2f);
				StaticValues.CurrentSubScene = " ";
			}
			break;
		case "LP_2":
			if (Time.time - sceneStartTime > 4.5f && Time.time - sceneStartTime < 4.7f) {
				StaticValues.CurrentHUDMessage = StoryText.LieutenantPodLines [2];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
			}
			if (Time.time - sceneStartTime > 7.0f && Time.time - sceneStartTime < 7.2f) {
				StaticValues.CurrentHUDMessage = StoryText.LieutenantPodLines [3];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (4f);
				StaticValues.CurrentSubScene = " ";
				StaticValues.CurrentObjective = StoryText.Objectives [12];
			}
			break;
		case "LP_3":
			if (Time.time - sceneStartTime > 0.5f && Time.time - sceneStartTime < 0.7f) {
				StaticValues.CurrentHUDMessage = StoryText.LieutenantPodLines [4];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
				StaticValues.CurrentSubScene = " ";
				StaticValues.CurrentObjective = StoryText.Objectives [13];
			}
			break;
		default:
			break;
		}
	}

	public void CollectGun() {
		Destroy (gun);
		StaticValues.IsGunCollected = true;
		collectGunAudioSource.clip = collectGunAudio;
		collectGunAudioSource.Play ();
		sceneStartTime = Time.time;
		StaticValues.CurrentSubScene = "LP_3";
		sliderCanvas.gameObject.SetActive (false);
	}

	public void EnterGun() {
		PointerEnter ();
	}

	public void ExitGun() {
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
