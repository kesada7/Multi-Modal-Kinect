using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "weapon")
        {
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
