using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraint : MonoBehaviour {
    GameObject leftHand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.rotation.y = 0;
        transform.rotation = Quaternion.Euler(95, -20, 0);
        //transform.rotation.y = Mathf.Clamp(transform.rotation.y, -30.0, 30.0);
    }
}
