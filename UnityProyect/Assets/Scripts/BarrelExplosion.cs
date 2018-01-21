using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour
{
    public GameObject explosion;
    public GameObject barrel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("weapon"))
        {
            Instantiate(explosion, barrel.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
