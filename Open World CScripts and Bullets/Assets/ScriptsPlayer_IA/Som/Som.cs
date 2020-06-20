using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Som : MonoBehaviour
{
    AudioSource As;
    public AudioClip arquivo;

    private void Awake()
    {
        As = GetComponent<AudioSource>();
    }

    private void Start()
    {
        As.clip = arquivo;
        As.Play();
        Destroy(gameObject, arquivo.length);
    }
    //colocar na camera Audio Listener componente
}
