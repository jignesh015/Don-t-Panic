using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorPodScript : MonoBehaviour {

	public List<GameObject> collectibles;
	public Canvas hudCanvas;

	private float sceneStartTime;

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
		}
	}
	
	// Update is called once per frame
	void Update () {
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
			}
			break;
		default:
			break;
		}
	}
}
