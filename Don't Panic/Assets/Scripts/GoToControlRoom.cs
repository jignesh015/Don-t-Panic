using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToControlRoom : MonoBehaviour {

	//public GameObject door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void goOut() {
		Debug.Log ("Go out");
		SceneManager.LoadScene ("Main");
	}
}
