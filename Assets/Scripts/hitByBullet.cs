﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitByBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider col) {
		GameObject.Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
