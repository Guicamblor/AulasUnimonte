using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ATK_IA : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public GameObject lugarBullet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            InvokeRepeating("Atacar", 0f, 3f);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            CancelInvoke("Atacar");
    }

    void Atacar()
    {
            Instantiate(bullet, lugarBullet.transform.position, lugarBullet.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10000);
    }
}
