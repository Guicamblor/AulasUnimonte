using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEfeito : MonoBehaviour
{
    public GameObject fxPrefab;
    public float time = 3;
    void Start()
    {
        Instantiate(fxPrefab, transform.position, transform.rotation);
        Destroy(gameObject, time);
    }
}
