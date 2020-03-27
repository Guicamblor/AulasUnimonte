using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IATIRO : MonoBehaviour
{
    public GameObject bullet;
    public GameObject lugarBullet;


    void Update()
    {
        Atacando();
    }

    void Atacando()
    {
        Instantiate(bullet, lugarBullet.transform.position, lugarBullet.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
    }


    //void Atirando()
    //{
    
    //Instantiate(bullet, lugarBullet.transform.position, lugarBullet.transform.rotation);
    //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
    //} 
}
