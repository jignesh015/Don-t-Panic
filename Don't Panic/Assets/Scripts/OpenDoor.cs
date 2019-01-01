using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour {

	public Animator doorAnimator;

	public GameObject consoleScreen;

	public Material doorOpeningMaterial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Open_Door(string sceneName) {
		Debug.Log ("Opening door");
		consoleScreen.GetComponent<MeshRenderer> ().material = doorOpeningMaterial;
		doorAnimator.SetBool ("OpenDoor", true);
		StartCoroutine(ChangeScene(sceneName));
	}

	IEnumerator ChangeScene(string sceneName)
	{
		yield return new WaitForSeconds(1.9f);
		SceneManager.LoadScene (sceneName);
	}
}
