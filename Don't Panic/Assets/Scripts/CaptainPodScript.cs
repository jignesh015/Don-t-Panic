using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainPodScript : MonoBehaviour {

	public List<GameObject> collectibles;

	// Use this for initialization
	void Start () {
		if (StaticValues.CollectibleList.Count > 0) {
			if (StaticValues.CollectibleList.Contains ("cp_art_0")) {
				Destroy (collectibles [0]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
