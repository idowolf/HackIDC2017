using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpwards : MonoBehaviour {
    public float velocity = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.y += velocity*Time.deltaTime;
        transform.position = pos;
	}
}
