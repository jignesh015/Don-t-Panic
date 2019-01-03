using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRoomScript : MonoBehaviour {

	public GameObject computerScreen;
	public GameObject bigScreen;

	public Material warningSwitchedOffMat;
	public Material bigScreenMat;
	public Material highlightMat;

	public ParticleSystem destroyEffect;

	private Material ogMat;

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

	public void CollectArtwork(GameObject collectible) {
		destroyEffect.gameObject.transform.position = collectible.transform.position;
		Destroy (collectible);
		destroyEffect.Play ();
		StaticValues.CollectibleScore = 1;
		Debug.Log (StaticValues.CollectibleScore);
	}

	public void HighlightObj(GameObject obj) {
		ogMat = obj.GetComponent<MeshRenderer> ().material;

		obj.GetComponent<MeshRenderer> ().material = highlightMat;
	}

	public void UnhighlightObj(GameObject obj) {
		obj.GetComponent<MeshRenderer> ().material = ogMat;
	}
}
