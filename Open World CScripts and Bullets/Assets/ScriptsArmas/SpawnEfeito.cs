using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEfeito : MonoBehaviour
{
    public GameObject fxPrefab;
    void Start()
    {
        Instantiate(fxPrefab, transform.position, transform.rotation);
    }
}
