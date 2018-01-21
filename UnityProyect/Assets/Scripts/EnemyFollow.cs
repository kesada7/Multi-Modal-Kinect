using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    //public Transform player;
    public float walkDistance = 1000.0f;
    public float smoothTime = 10.0f;


    private GameObject target;

    private bool moveEnemy =  true;
    private Vector3 smoothVelocity = Vector3.zero;

    public GameObject gestures;

    private void Start()
    {
        target = GameObject.FindWithTag("Player");


        

    }
    void Update()
    {
        //shield.GetComponent<GestureTest>().moveEnemy;
        //player = GameObject.FindWithTag("player");
        transform.LookAt(target.transform);

        float Distance = Vector3.Distance(transform.position, target.transform.position);

        if (Distance < walkDistance && moveEnemy == true)
        {
            
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref smoothVelocity, smoothTime);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("shield"))
        {
            moveEnemy = false;
        }
    }

}
