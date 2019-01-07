using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPodScript : MonoBehaviour {

	public List<GameObject> collectibles;
	public Canvas fadeInCanvas;
	public GameObject startPositionWaypoint;
	public GameObject mainCamera;

	// Use this for initialization
	void Start () {
		//Fade in effect fo 1st load
		if (StaticValues.IsFirstLoad) {
			fadeInCanvas.gameObject.SetActive (true);
			StaticValues.IsFirstLoad = false;
			mainCamera.transform.position = startPositionWaypoint.transform.position;
			mainCamera.transform.rotation = Quaternion.Euler (0, -90, 0);
		} else {
			Destroy (fadeInCanvas.gameObject);
		}

		//Destroy already collected artworks
		if (StaticValues.CollectibleList.Count > 0) {
			if (StaticValues.CollectibleList.Contains ("pl_art_0")) {
				Destroy (collectibles [0]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}




}
