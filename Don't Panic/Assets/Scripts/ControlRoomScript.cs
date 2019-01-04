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

	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;

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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwitchOffWarning() {
		computerScreen.GetComponent<MeshRenderer> ().material = warningSwitchedOffMat;
		bigScreen.GetComponent<MeshRenderer> ().material = bigScreenMat;
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
