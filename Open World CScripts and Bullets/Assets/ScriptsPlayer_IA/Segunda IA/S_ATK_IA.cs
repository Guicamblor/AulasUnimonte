using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class S_ATK_IA : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public int vida = 100;
    public NavMeshAgent agent;
    void Update()
    {
        StartandoEstados();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            Invoke("EstadoAtaque", 0.5f);
        if (other.gameObject.tag == "Balas")
        {
            estado = Estados.damage;
            vida -= 10;
            if (vida == 0)
            {
                estado = Estados.morte;
            }
            Invoke("EstadoAtaque", 0.5f);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Invoke("EstadoAtaque", 0.5f);

        if (other.gameObject.tag == "Arma")
        {
            vida -= 10;
            if (vida == 0)
            {
                estado = Estados.morte;
            }
        }
    }
    public enum Estados
    {
        perseguir,
        ataque,
        Idle,
        morte,
        damage,
    }
    public Estados estado;
    void StartandoEstados()
    {
        switch (estado)
        {
            case Estados.perseguir:
                EstadoPerseguir();
                break;
            case Estados.ataque:
                EstadoAtaque();
                break;
            case Estados.Idle:
                EstadoParado();
                break;
            case Estados.morte:
                EstadoMorto();
                break;
            case Estados.damage:
                EstadoDamage();
                break;
        }
    }
    void EstadoPerseguir()
    {
        agent.isStopped = false;
        anim.SetBool("Defend", false);
        anim.SetBool("Smash Attack", false);
        anim.SetBool("Take Damage 0", false);
        anim.SetBool("Walk Forward", true);
        anim.SetBool("Die", false);
        if (Vector3.Distance(transform.position, player.transform.position) < 4)
        {
            estado = Estados.ataque;
        }
    }
    void EstadoAtaque()
    {
        agent.isStopped = true;
        anim.SetBool("Defend", false);
        anim.SetBool("Smash Attack", true);
        anim.SetBool("Take Damage 0", false);
        anim.SetBool("Walk Forward", false);
        anim.SetBool("Die", false);
        if (Vector3.Distance(transform.position, player.transform.position) > 5)
        {
            estado = Estados.perseguir;
        }
    }
    void EstadoParado()
    {
        agent.isStopped = false;
        anim.SetBool("Defend", true);
        anim.SetBool("Smash Attack", false);
        anim.SetBool("Take Damage 0", false);
        anim.SetBool("Walk Forward", false);
        anim.SetBool("Die", false);
    }
    void EstadoMorto()
    {
        agent.isStopped = false;
        anim.SetBool("Defend", false);
        anim.SetBool("Smash Attack", false);
        anim.SetBool("Take Damage 0", false);
        anim.SetBool("Walk Forward", false);
        anim.SetBool("Die", true);
        Destroy(gameObject, 0.9f);
    }
    void EstadoDamage()
    {
        agent.isStopped = false;
        anim.SetBool("Defend", false);
        anim.SetBool("Smash Attack", false);
        anim.SetBool("Take Damage 0", true);
        anim.SetBool("Walk Forward", false);
        anim.SetBool("Die", false);
        Invoke("EstadoAtaque", 0.5f);
    }

}
