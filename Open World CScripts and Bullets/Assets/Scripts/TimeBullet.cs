using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBullet : MonoBehaviour
{
    public ControladorDoTempo controladordetempo;
    Vector3 mover;
    void Start()
    {
        Invoke("Explode", 3);
    }
    void Explode()//adiciona todo mundo em uma esfera invisivel e para explodir ele vai passando em cada um para adicionar uma força que colocarmos por isso da o efeito de explosão 
    {
        print("Boom!");
        Destroy(gameObject);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)//para cada
            {
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddExplosionForce(1000, transform.position, 10);
                    controladordetempo.DoSlowmotion();
                }

            }
        }

    }
}
