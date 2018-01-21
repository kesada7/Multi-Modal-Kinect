using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour {

    public float speed;

    private Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {
        rig.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
