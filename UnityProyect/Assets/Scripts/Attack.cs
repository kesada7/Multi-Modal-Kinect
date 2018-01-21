using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public GameObject shot;
    public Transform shotSpawn;
    private float fireRate = 0.5f;
    private float nextFire;
    bool gunActive = true;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ShootArrow();

    }


    void ShootArrow()
    {
        
            //Here we instantiate bullets when we press fire1 and the time passed is at least 0,5 seconds 
            //if (Input.GetButton("Fire1") && Time.time > nextFire && gunActive == true)
           // {
               // nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.transform.rotation);
                
               
            //}
            
        
    }
}
