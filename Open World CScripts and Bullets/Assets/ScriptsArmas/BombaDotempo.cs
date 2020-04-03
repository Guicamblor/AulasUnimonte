using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaDotempo : MonoBehaviour
{
    public float bombForce = 1000;
    Rigidbody rdb;
    public float segundos = 2f;
    public GameObject fxPrefab;
    private void Start()
    {
        rdb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        rdb.isKinematic = true;
        Instantiate(fxPrefab, transform.position, transform.rotation);
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
    private void OnTriggerEnter(Collider other)
    {
        if (rdb.isKinematic)
            StartCoroutine("Contagem");
    }
    IEnumerable Contagem()
    {
        yield return new WaitForSeconds(segundos);
    }

}
