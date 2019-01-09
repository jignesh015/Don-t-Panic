using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScreenScript : MonoBehaviour {

	public AudioSource mainAudioSource;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame() {
		mainAudioSource.Play ();
		SceneManager.LoadScene ("Player_pod");
	}
}
