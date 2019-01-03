using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRoomScript : MonoBehaviour {

	public GameObject computerScreen;
	public GameObject bigScreen;

	public Material warningSwitchedOffMat;
	public Material bigScreenMat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwitchOffWarning() {
		computerScreen.GetComponent<MeshRenderer> ().material = warningSwitchedOffMat;
		bigScreen.GetComponent<MeshRenderer> ().material = bigScreenMat;
	}
}
