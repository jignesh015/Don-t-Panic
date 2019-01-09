using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LieutenantPodScript : MonoBehaviour {

	public List<GameObject> collectibles;

	public Canvas hudCanvas;

	private float sceneStartTime;
	private bool lieutenantLogFlag = true;

	// Use this for initialization
	void Start () {
		sceneStartTime = Time.time;

		if (StaticValues.CollectibleList.Count > 0) {
			if (StaticValues.CollectibleList.Contains ("lt_art_0")) {
				Destroy (collectibles [0]);
			}
		}

		if (!StaticValues.CheckedLieutenantLog) {
			StaticValues.CurrentSubScene = "LP_1";
		} else {
			lieutenantLogFlag = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (StaticValues.CheckedLieutenantLog && lieutenantLogFlag) {
			lieutenantLogFlag = false;
			StaticValues.CurrentSubScene = "LP_2";
			sceneStartTime = Time.time;
		}

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
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (2f);
			}
			if (Time.time - sceneStartTime > 6.0f && Time.time - sceneStartTime < 6.2f) {
				StaticValues.CurrentHUDMessage = StoryText.LieutenantPodLines [3];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (2f);
				StaticValues.CurrentSubScene = " ";
				StaticValues.CurrentObjective = StoryText.Objectives [12];
			}
			break;
		default:
			break;
		}
	}
}
