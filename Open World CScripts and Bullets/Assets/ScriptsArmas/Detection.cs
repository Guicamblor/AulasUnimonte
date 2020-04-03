using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    Rigidbody rdb;
    public float bombForce =2000;
    public float segundos = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("bati");
        rdb.isKinematic = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (rdb.isKinematic)
            StartCoroutine("Contagem");
    }


    void Explode()
    {
        print("Boom!");
        Destroy(gameObject);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.rigidbody)
                    hit.rigidbody.AddExplosionForce(bombForce, transform.position, 10);
            }
        }
    }

    IEnumerable Contagem()
    {
        Explode();
        yield return new WaitForSeconds(segundos);
    }
}
