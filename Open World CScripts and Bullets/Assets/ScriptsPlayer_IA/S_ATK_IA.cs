using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ATK_IA : MonoBehaviour
{
    public GameObject player;
    public bool Atack;
    public GameObject bullet;
    public GameObject lugarBullet;

    void Update()
    {
      Atacar();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Atack = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            Atack = false;
    }

    void Atacar()
    {
        if (Atack == true)
        {
            Instantiate(bullet, lugarBullet.transform.position, lugarBullet.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10000);
        }
    }
    
}
