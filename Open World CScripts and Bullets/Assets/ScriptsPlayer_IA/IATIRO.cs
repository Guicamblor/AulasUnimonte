using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IATIRO : MonoBehaviour
{
    public GameObject bullet;
    bool atacando;

    void Update()
    {
        Atacando();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            atacando = true;
            if (atacando == true)
                Atacando();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        atacando = false;
    }
    void Atacando()
    {
        if(atacando == true)
        {
            Instantiate(bullet, transform.position + transform.forward, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10000);
        }
    }

    //void Atirando()
    //{

    //Instantiate(bullet, lugarBullet.transform.position, lugarBullet.transform.rotation);
    //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
    //} 
}
