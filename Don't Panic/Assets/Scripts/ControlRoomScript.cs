using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRoomScript : MonoBehaviour {

	public GameObject computerScreen;
	public GameObject bigScreen;

	public Material warningSwitchedOffMat;
	public Material bigScreenMat;

	public ParticleSystem destroyEffect;

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
}
