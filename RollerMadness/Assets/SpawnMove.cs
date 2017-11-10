using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMove : MonoBehaviour {

	public float range;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Random.Range(-range, range), 34, 0);
	}
}
