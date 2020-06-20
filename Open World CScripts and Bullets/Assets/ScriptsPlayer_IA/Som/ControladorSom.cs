using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSom : MonoBehaviour
{
    //colocar esse script na camera
    public enum Toques
    {
        Andar,
        Explosao,
        Atack,
        DanoIa
    }
    public GameObject SomPrefab;
    public AudioClip[] Sons;

    public void Ouvir(Toques efeitoS)
    {
        GameObject novoSom = Instantiate<GameObject>(SomPrefab, transform.position, Quaternion.identity);
        Som novoSom_Compo = novoSom.GetComponent<Som>();

        int numeroDoSom = (int)efeitoS;
        AudioClip EfeitoSonoro = Sons[numeroDoSom];

        novoSom_Compo.arquivo = EfeitoSonoro;
    }
    /*Controlador SDS
void Awake(){
   SDS = GameObject.FindWithTag("MainCamera").GetComponent<ControladorSom.();
}

public void Atacar(){
   vidaJogador.vida = vidaJogador.vida - dano;
   SDS.Ouvir(ControladorSom.efeitoS.DanoIa);
}
*/
}
