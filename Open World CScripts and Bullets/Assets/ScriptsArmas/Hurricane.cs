using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurricane : MonoBehaviour
{
    Rigidbody rdb;
    public float bombForce = -2000;
    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rdb.AddTorque(Vector3.up * 100);
        rdb.AddForce(transform.forward, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (other.attachedRigidbody)
        {
            other.transform.parent = transform;
        }
    }
    
}
