using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactoryLogic : MonoBehaviour {
    public GameObject bullet;
    private float timeElapsed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= 0.5f)
        {
            timeElapsed = 0;
            GameObject.Instantiate(bullet);
        }
	}
}
