using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb2 : MonoBehaviour
{
    public float bombForce = 1000;
    public GameObject efeito;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Efeitos", 3);
        Invoke("Explode", 3);
    }

    // Update is called once per frame
    void Explode()//adiciona todo mundo em uma esfera invisivel e para explodir ele vai passando em cada um para adicionar uma força que colocarmos por issod a o efeito de explosão 
    {
        print("Boom!");
        Destroy(gameObject);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach(RaycastHit hit in hits)//para cada
            {
                if (hit.rigidbody)
                hit.rigidbody.AddExplosionForce(bombForce, transform.position, 10);
                
            }
        }
        
    }
    void Efeitos()
    {
        Instantiate(efeito, transform.position, Quaternion.identity);
    }
}
