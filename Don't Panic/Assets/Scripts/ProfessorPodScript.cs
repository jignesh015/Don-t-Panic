using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorPodScript : MonoBehaviour {

	public List<GameObject> collectibles;
	public Canvas hudCanvas;

	private float sceneStartTime;
	private bool profLogFlag = true;

	// Use this for initialization
	void Start () {
		sceneStartTime = Time.time;
		if (StaticValues.CollectibleList.Count > 0) {
			if (StaticValues.CollectibleList.Contains ("pf_art_0")) {
				Destroy (collectibles [0]);
			}
		}

		if (!StaticValues.CheckedProfLogs) {
			StaticValues.CurrentSubScene = "PF_1";
		} else {
			profLogFlag = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (StaticValues.CheckedProfLogs && profLogFlag) {
			profLogFlag = false;
			StaticValues.CurrentSubScene = "PF_2";
			sceneStartTime = Time.time;
		}

		//Story text
		switch(StaticValues.CurrentSubScene)
		{
		case "PF_1":
			if (Time.time - sceneStartTime > 1.5f && Time.time - sceneStartTime < 1.7f) {
				StaticValues.CurrentHUDMessage = StoryText.ProfessorPodLines [0];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (2f);
			}
			if (Time.time - sceneStartTime > 2.5f && Time.time - sceneStartTime < 2.7f) {
				StaticValues.CurrentHUDMessage = StoryText.ProfessorPodLines [1];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (2f);
			}
			if (Time.time - sceneStartTime > 5.5f && Time.time - sceneStartTime < 5.7f) {
				StaticValues.CurrentHUDMessage = StoryText.ProfessorPodLines [2];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (3f);
				StaticValues.CurrentObjective = StoryText.Objectives [4];
				StaticValues.CurrentSubScene = " ";
			}
			break;
		case "PF_2":
			if (Time.time - sceneStartTime > 3.5f && Time.time - sceneStartTime < 3.7f) {
				StaticValues.CurrentHUDMessage = StoryText.ProfessorPodLines [3];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (2f);
				if (!StaticValues.CheckedCaptainLog) {
					StaticValues.CurrentSubScene = "PF_3";
					sceneStartTime = Time.time;
				} else {
					StaticValues.CurrentSubScene = " ";
				}
			}
			break;
		case "PF_3":
			if (Time.time - sceneStartTime > 1.0f && Time.time - sceneStartTime < 1.2f) {
				StaticValues.CurrentHUDMessage = StoryText.ProfessorPodLines [4];
				hudCanvas.gameObject.GetComponent<HUDLogic> ().ShowMessage (2f);
				StaticValues.CurrentSubScene = " ";
				StaticValues.CurrentObjective = StoryText.Objectives [6];
			}
			break;
		default:
			break;
		}
	}
}
