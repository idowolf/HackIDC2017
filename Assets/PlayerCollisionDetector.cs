using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour {

	// Use this for initialization
	public int hp = 100;
	void Start () {
		
	}
		void OnTriggerEnter(Collider col) {
			hp -= 10;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
