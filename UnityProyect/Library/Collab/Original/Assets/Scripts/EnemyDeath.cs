using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

    //void OnCollisionEnter(Collision col)
    //{
    //    if(col.gameObject.tag == "weapon")
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("weapon"))
        {
            Destroy(this.gameObject);
            
            //Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
