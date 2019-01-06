using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour {

	public Canvas sliderCanvas;
	public Slider slider;

	public Text currentObjText;
	public Text artworksText;

	public Canvas mainHUD;
	public Text hudText;

	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;
	private bool isCurrentObjBtn;

	// Use this for initialization
	void Start () {
		slider.maxValue = hoverTime;
		sliderCanvas.gameObject.SetActive (false);

		currentObjText.gameObject.SetActive (false);
		artworksText.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (pointerFlag) {
			//Sets the progress slider value
			float sliderValue = Time.time - enterTime;
			slider.value = sliderValue;

			if ((Time.time - enterTime) > hoverTime) {
				if (isCurrentObjBtn) {
					currentObjective ();
				} else {
					artworksCollected ();
				}
				pointerFlag = false;
			}
		}
	}

	public void currentObjective() {
		mainHUD.gameObject.SetActive (true);
		hudText.text = StaticValues.CurrentObjective;
	}

	public void artworksCollected() {
		mainHUD.gameObject.SetActive (true);
		hudText.text = "Artworks Collected: \n" + StaticValues.CollectibleScore.ToString() + "/7";
	}

	public void enterCurrentObj() {
		currentObjText.gameObject.SetActive (true);
		isCurrentObjBtn = true;
		PointerEnter ();
	}

	public void exitCurrentObj() {
		currentObjText.gameObject.SetActive (false);
		PointerExit ();
	}

	public void enterArtworksCollected() {
		artworksText.gameObject.SetActive (true);
		isCurrentObjBtn = false;
		PointerEnter ();
	}

	public void exitArtworksCollected() {
		artworksText.gameObject.SetActive (false);
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

	public void Test() {
		Debug.Log ("Test button");
	}
}
