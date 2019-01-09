using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDLogic : MonoBehaviour {

	public Text hudText;

	private bool activeFlag = false;
	private float activeTime;
	private float limit = 2.0f;
	private Color colorFlag = new Color(0,0,0,0);

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (activeFlag) {
			if ((Time.time - activeTime) > limit) {
				gameObject.SetActive (false);
				activeFlag = false;
			}
		}
	}

	public void ShowMessage(float limitArg = 2.0f, Color txtColor = default(Color)) {
		gameObject.SetActive (true);
		activeFlag = true;
		activeTime = Time.time;
		limit = limitArg;

		hudText.text = StaticValues.CurrentHUDMessage;
		if (txtColor == colorFlag) {
			hudText.color = new Color (1, 1, 1, 1);
		} else {
			hudText.color = txtColor;
		}
	}
}
