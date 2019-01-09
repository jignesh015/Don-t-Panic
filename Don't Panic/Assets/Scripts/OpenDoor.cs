using System.Collections;
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

	public AudioClip doorClip;

	private bool pointerFlag = false;
	private float enterTime;
	private float hoverTime = 1.5f;
	private string _sceneName;
	private AudioSource _doorAudioSource;

	// Use this for initialization
	void Start () {
		slider.maxValue = hoverTime;
		sliderCanvas.gameObject.SetActive (false);

		_doorAudioSource = gameObject.GetComponent<AudioSource> ();
		_doorAudioSource.clip = doorClip;
		_doorAudioSource.playOnAwake = false;
		_doorAudioSource.volume = 0.5f;
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

//	public void Open_Door(string sceneName) {
//		_sceneName = sceneName;
//		consoleScreen.GetComponent<MeshRenderer> ().material = doorOpeningMaterial;
//		doorAnimator.SetBool ("OpenDoor", true);
//		_doorAudioSource.Play ();
//		StartCoroutine(ChangeScene(_sceneName));
//	}

	public void Open_Door(string sceneName) {
		switch(sceneName) 
		{
		case "Lieutenant_pod":
			if (!StaticValues.CheckedCaptainLog) {
				StaticValues.CurrentSubScene = "CR_7";
			} else {
				OpenDoorLogic (sceneName);
			}
			break;
		case "Storage_room_1":
			if (!StaticValues.CheckedAlienPod) {
				StaticValues.CurrentSubScene = "CR_8";
			} else {
				OpenDoorLogic (sceneName);
			}
			break;
		case "Storage_room_2":
			if (!StaticValues.CheckedLieutenantLog) {
				StaticValues.CurrentSubScene = "CR_9";
			} else {
				OpenDoorLogic (sceneName);
			}
			break;
		default:
			OpenDoorLogic (sceneName);
			break;
		}
	}

	private void OpenDoorLogic(string sceneName) {
		_sceneName = sceneName;
		consoleScreen.GetComponent<MeshRenderer> ().material = doorOpeningMaterial;
		doorAnimator.SetBool ("OpenDoor", true);
		_doorAudioSource.Play ();
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
