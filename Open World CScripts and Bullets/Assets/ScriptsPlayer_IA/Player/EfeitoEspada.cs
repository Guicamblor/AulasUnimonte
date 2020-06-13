using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoEspada : MonoBehaviour
{
    public GameObject efeito;
    public GameObject local;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Inimigo")
        {
            Instantiate(efeito, local.transform.position, local.transform.rotation);
        }
    }
}
