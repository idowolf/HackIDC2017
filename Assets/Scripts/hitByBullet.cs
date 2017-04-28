using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitByBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider col) {
		Debug.Log("test");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
