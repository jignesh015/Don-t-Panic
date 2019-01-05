using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleScript : MonoBehaviour {

	public Material highlightMat;
	public ParticleSystem destroyEffect;

	public Canvas sliderCanvas;
	public Slider slider;

	public AudioClip collectibleAudio;

	private Material ogMat;
	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;
	private GameObject focusedObj;
	private AudioSource _collectibleAudioSource;

	// Use this for initialization
	void Start () {
		slider.maxValue = hoverTime;
		sliderCanvas.gameObject.SetActive (false);

		_collectibleAudioSource = gameObject.GetComponent<AudioSource> ();
		_collectibleAudioSource.clip = collectibleAudio;
		_collectibleAudioSource.playOnAwake = false;
		_collectibleAudioSource.volume = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (pointerFlag) {
			//Sets the progress slider value
			float sliderValue = Time.time - enterTime;
			slider.value = sliderValue;

			if ((Time.time - enterTime) > hoverTime) {
				Collect (focusedObj);
				pointerFlag = false;
			}
		}
	}

	public void Collect(GameObject collectible) {
		destroyEffect.gameObject.transform.position = collectible.transform.position;
		StaticValues.CollectibleList.Add (collectible.name);
		Destroy (collectible);
		destroyEffect.Play ();
		_collectibleAudioSource.Play ();
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
