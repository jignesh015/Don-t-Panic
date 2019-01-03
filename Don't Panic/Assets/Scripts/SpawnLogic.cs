using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour {

	public List<GameObject> spawnToWaypoints;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Awake() {
		transform.position = spawnToWaypoints [StaticValues.SpawnToWaypoint].transform.position;
	}
		
}
