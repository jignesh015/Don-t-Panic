using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlRoomScript : MonoBehaviour {

	public GameObject computerScreen;
	public GameObject bigScreen;

	public Material warningSwitchedOffMat;
	public Material bigScreenMat;
	public Material highlightMat;

	public ParticleSystem destroyEffect;

	public Canvas sliderCanvas;

	public Slider slider;

	private Material ogMat;
	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;
	private GameObject focusedObj;

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
				CollectArtwork (focusedObj);
				pointerFlag = false;
			}
		}
	}

	public void SwitchOffWarning() {
		computerScreen.GetComponent<MeshRenderer> ().material = warningSwitchedOffMat;
		bigScreen.GetComponent<MeshRenderer> ().material = bigScreenMat;
	}

	public void CollectArtwork(GameObject collectible) {
		destroyEffect.gameObject.transform.position = collectible.transform.position;
		Destroy (collectible);
		destroyEffect.Play ();
		StaticValues.CollectibleScore = 1;
		Debug.Log (StaticValues.CollectibleScore);
		PointerExit ();
	}

	public void HighlightObj(GameObject obj) {
		focusedObj = obj;
		PointerEnter ();

		ogMat = obj.GetComponent<MeshRenderer> ().material;
		obj.GetComponent<MeshRenderer> ().material = highlightMat;
	}

	public void UnhighlightObj(GameObject obj) {
		PointerExit ();

		obj.GetComponent<MeshRenderer> ().material = ogMat;
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
