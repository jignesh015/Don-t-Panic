using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCreditScript : MonoBehaviour {

	public Canvas sliderCanvas;
	public Slider slider;

	public AudioSource mainAudioSource;

	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;

	// Use this for initialization
	void Start () {
		slider.maxValue = hoverTime;
		sliderCanvas.gameObject.SetActive (false);
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
}
