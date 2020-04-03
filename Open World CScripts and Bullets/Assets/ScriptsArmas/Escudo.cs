using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    public GameObject myOwner;
    public float duration;
    float timer;
    void Start()
    {
        timer = duration;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        transform.position = myOwner.transform.position;

        if (timer <= 0)
        {
            Morte();
        }
    }

    public void Morte()
    {
        Destroy(gameObject);
    }
}
