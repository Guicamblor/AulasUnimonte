﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    Rigidbody rdb;
    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("bati");
        rdb.isKinematic = true;
    }
}
