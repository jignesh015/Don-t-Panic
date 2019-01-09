using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainPodScript : MonoBehaviour {

	public List<GameObject> collectibles;
	public Canvas hudCanvas;

	private float sceneStartTime;
	private bool captainLogFlag = true;

	// Use this for initialization
	void Start () {
		sceneStartTime = Time.time;

		if (StaticValues.CollectibleList.Count > 0) {
			if (StaticValues.CollectibleList.Contains ("cp_art_0")) {
				Destroy (collectibles [0]);
			}
		}

		if (!StaticValues.CheckedCaptainLog) {
			StaticValues.CurrentSubScene = "CP_1";
		} else {
			captainLogFlag = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (StaticValues.CheckedCaptainLog && captainLogFlag) {
			Debug.Log ("Inside checked cap log");
			captainLogFlag = false;
			StaticValues.CurrentSubScene = "CP_2";
			sceneStartTime = Time.time;
		}

		//Story text
		switch(StaticValues.CurrentSubScene)
		{
		case "CP_1":
			if (Time.time - sceneStartTime > 1.5f && Time.time - sceneStartTime < 1.7f) {
				StaticValues.CurrentHUDMessage = StoryText.CaptainPodLines [0];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (2f);
				StaticValues.CurrentSubScene = " ";
			}
			break;
		case "CP_2":
			if (Time.time - sceneStartTime > 4.5f && Time.time - sceneStartTime < 4.7f) {
				StaticValues.CurrentHUDMessage = StoryText.CaptainPodLines [1];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (2f);
			}
			if (Time.time - sceneStartTime > 6.5f && Time.time - sceneStartTime < 6.7f) {
				StaticValues.CurrentHUDMessage = StoryText.CaptainPodLines [2];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
				StaticValues.CurrentSubScene = " ";
				StaticValues.CurrentObjective = StoryText.Objectives [9];
			}
			break;
		default:
			break;
		}
	}
}
