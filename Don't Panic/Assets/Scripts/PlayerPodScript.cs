using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPodScript : MonoBehaviour {

	public List<GameObject> collectibles;
	public Canvas fadeInCanvas;
	public GameObject startPositionWaypoint;
	public GameObject mainCamera;
	public Canvas hudCanvas;

	private bool storyFlag = true;

	// Use this for initialization
	void Start () {
		//Fade in effect fo 1st load
		if (StaticValues.IsFirstLoad) {
			fadeInCanvas.gameObject.SetActive (true);
			StaticValues.IsFirstLoad = false;
			mainCamera.transform.position = startPositionWaypoint.transform.position;
			mainCamera.transform.rotation = Quaternion.Euler (0, -90, 0);
		} else {
			Destroy (fadeInCanvas.gameObject);
		}

		//Destroy already collected artworks on scene load
		if (StaticValues.CollectibleList.Count > 0) {
			if (StaticValues.CollectibleList.Contains ("pl_art_0")) {
				Destroy (collectibles [0]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Story texts
		if (Time.time > 5.0f && Time.time < 5.2f) {
			StaticValues.CurrentHUDMessage = StoryText.PlayerPodLines[0];
			hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
		}
		if (Time.time > 10.0f && Time.time < 10.2f) {
			StaticValues.CurrentHUDMessage = StoryText.PlayerPodLines[1];
			hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
		}
		if (Time.time > 14.0f && Time.time < 14.2f) {
			StaticValues.CurrentHUDMessage = StoryText.PlayerPodLines[2];
			hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3.0f);
			StaticValues.CurrentObjective = StoryText.Objectives [1];
		}
	}




}
