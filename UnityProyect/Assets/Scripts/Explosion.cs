using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float radius = 3.0f;
    public float power = 800.0f;
    public float explosiveLift = 1.0f;
    public float explosiveDelay = 0.1f;
    public GameObject barrel;

    public Transform explosionFX;

	void Start ()
    {
        StartCoroutine(Explode());
	}
	
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(explosiveDelay);
        Vector3 barrelOrigin = transform.position;
        Collider[] Colliders = Physics.OverlapSphere(barrelOrigin, radius);

        foreach(Collider hit in Colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(power, barrelOrigin, radius, explosiveLift);
            }

            if(hit.CompareTag("enemy"))
            {
                hit.SendMessage("Enemy Hit", transform);
            }
        }

        Instantiate(explosionFX, barrel.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

	void Update ()
    {
		
	}
}
