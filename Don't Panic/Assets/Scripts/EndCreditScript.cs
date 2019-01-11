using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCreditScript : MonoBehaviour {

	public Canvas sliderCanvas;
	public Slider slider;
	public AudioSource mainAudioSource;
	public List<Text> stats;

	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;

	// Use this for initialization
	void Start () {
		slider.maxValue = hoverTime;
		sliderCanvas.gameObject.SetActive (false);

		stats [0].text = StoryText.CreditStats[0] + StaticValues.CollectibleScore.ToString() + StoryText.CreditStats[1];
		stats[1].text = StaticValues.KilledAlien?StoryText.CreditStats[3]:StoryText.CreditStats[2];
		stats[2].text = StaticValues.ChoseToWait?StoryText.CreditStats[4]:StoryText.CreditStats[5];
	}
	
	// Update is called once per frame
	void Update () {
		if (pointerFlag) {
			//Sets the progress slider value
			float sliderValue = Time.time - enterTime;
			slider.value = sliderValue;

			if ((Time.time - enterTime) > hoverTime) {
				RestartGame ();
				sliderCanvas.gameObject.SetActive (false);
				pointerFlag = false;
			}
		}
	}

	public void RestartGame() {
		ResetGame ();
		mainAudioSource.Play ();
		SceneManager.LoadScene ("Main");
	}

	public void EnterStart() {
		PointerEnter ();
	}

	public void ExitStart() {
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

	private void ResetGame() {
		StaticValues.IsFirstLoad = true;
		StaticValues.DontPanicFlag = true;
		StaticValues.CheckedProfLogs = false;
		StaticValues.CheckedPassword = false;
		StaticValues.CheckedCaptainDoor = false;
		StaticValues.CheckedCaptainLog = false;
		StaticValues.CheckedLieutenantLog = false;
		StaticValues.CheckedAlienPod = false;
		StaticValues.IsGunCollected = false;
		StaticValues.KilledAlien = false;
		StaticValues.ChoseToWait = false;
		StaticValues.SpawnToWaypoint = 0;
		StaticValues.CollectibleScore = 0;
		StaticValues.CurrentObjective = "...";
		StaticValues.CurrentHUDMessage = null;
		StaticValues.CurrentSubScene = "PlayerPod";
		StaticValues.CollectibleList = new List<string> ();
	}
}
