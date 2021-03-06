﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroDeAfastar : MonoBehaviour
{
    public GameObject player;
    public float segundos;
    public GameObject fxPrefab;
    void OnCollisionEnter(Collision collision)
    {
        Vector3 posicao = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1000);
        player.transform.position = posicao;
        Instantiate(fxPrefab, transform.position, transform.rotation);
        StartCoroutine("Destruicao");
    }
    IEnumerable Destruicao()
    {
        yield return new WaitForSeconds(segundos);
    }

}
