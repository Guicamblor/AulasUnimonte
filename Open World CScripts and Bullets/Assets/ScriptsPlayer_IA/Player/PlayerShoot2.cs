
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot2 : MonoBehaviour
{
    public GameObject[] projectilesPrefab;
    int indexWeapon;
    public GameObject shield;
    public GameObject fxPrefab;

    void Start()
    {
        
    }

    void Update()
    {

        float movx = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(-movx, 0, 0));

        if (Input.GetKey(KeyCode.Alpha1)) indexWeapon = 0;
        if (Input.GetKey(KeyCode.Alpha2)) indexWeapon = 1;
        if (Input.GetKey(KeyCode.Alpha3)) indexWeapon = 2;
        if (Input.GetKey(KeyCode.Alpha4)) indexWeapon = 3;
        if (Input.GetKey(KeyCode.Alpha5)) indexWeapon = 4;
        if (Input.GetKey(KeyCode.Alpha6)) indexWeapon = 5;
        if (Input.GetKey(KeyCode.Alpha7)) indexWeapon = 6;
        

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject myprojectile = Instantiate(projectilesPrefab[indexWeapon], transform.position + transform.forward, Quaternion.identity);

            myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 500);

        }

        bool AB1 = Input.GetKeyDown(KeyCode.Alpha8);

        if (AB1)
        {
            Ability1();
        }
    }
  
    void Ability1()
    {
        GameObject myShield = (GameObject)Instantiate(shield, transform.position, shield.transform.rotation);
        Escudo shieldScript = myShield.GetComponent<Escudo>();
        shieldScript.myOwner = this.gameObject;
        Instantiate(fxPrefab, transform.position, transform.rotation);
    }
}

