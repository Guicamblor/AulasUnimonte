using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub : MonoBehaviour
{
    public float bombForce = 100;
    public GameObject efeito;
    public int contagem;
    void Start()
    {
        Invoke("Efeitos", 3);
        Invoke("Explode", 3);
    }

    void Explode()
    {
        Destroy(gameObject);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.rigidbody)
                {
                    hit.rigidbody.isKinematic = false;
                    hit.rigidbody.AddExplosionForce(-bombForce, transform.position, 10);
                    
                }
            }
        }
    }
    void Efeitos()
    {
      Instantiate(efeito, transform.position, Quaternion.identity);
      Destroy(this);
    }



}
