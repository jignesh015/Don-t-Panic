﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour {

	public Animator doorAnimator;

	public GameObject consoleScreen;

	public Material doorOpeningMaterial;

	public int spawnToWaypoint;

	public Canvas sliderCanvas;
	public Slider slider;

	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;
	private string _sceneName;

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
				Open_Door (_sceneName);
				pointerFlag = false;
			}
		}
	}

	public void Open_Door(string sceneName) {
		_sceneName = sceneName;
		consoleScreen.GetComponent<MeshRenderer> ().material = doorOpeningMaterial;
		doorAnimator.SetBool ("OpenDoor", true);
		StartCoroutine(ChangeScene(_sceneName));
	}

	IEnumerator ChangeScene(string sceneName)
	{
		yield return new WaitForSeconds(1.9f);
		SceneManager.LoadScene (sceneName);
		StaticValues.SpawnToWaypoint = spawnToWaypoint;
	}

	public void Enter(string sceneName) {
		_sceneName = sceneName;
		PointerEnter ();
	}

	public void Exit() {
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
