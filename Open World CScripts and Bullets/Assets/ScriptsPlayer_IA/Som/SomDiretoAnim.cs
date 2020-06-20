using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomDiretoAnim : MonoBehaviour
{

    ControladorSom controleSom;

    private void Awake()
    {
        controleSom = GameObject.FindWithTag("MainCamera").GetComponent<ControladorSom>();
    }

    public void AnimEvent_Walk()
    {
        controleSom.Ouvir(ControladorSom.Toques.Andar);
    }
    public void AnimEvent_Ouvir_Hit()
    {
        controleSom.Ouvir(ControladorSom.Toques.Atack);
    }
}
