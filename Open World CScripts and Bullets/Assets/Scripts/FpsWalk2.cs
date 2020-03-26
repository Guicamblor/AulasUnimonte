using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsWalk2 : MonoBehaviour
{
    public CharacterController chtr;
    Vector3 move, rot;
    void Start()
    {
        //Caso você queira não arrastar ou esquecer ele fara isso, mas deixa também a opção de você arrastar tranquilamente, só fara se não houver nada na variavel.

        if (!chtr)
        {
            chtr = GetComponent<CharacterController>();
        }
        Cursor.lockState = CursorLockMode.Locked; //trava o cursor na tela até você apertar "Esc"
    }
    void Update()
    {
        //criacao de vetor de movimento local
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //captura de rotacao do corpo
        rot.y = Input.GetAxis("Mouse X");
        //conversao de direcao local pra global 
        Vector3 globalmove = transform.TransformDirection(move);
        chtr.SimpleMove(globalmove * 5);
        transform.Rotate(rot);

    }
    //void Update()
    //{
    //Para ler que esta andando para frente e usando a tecla W. Se ele clicar W. Move final é para zerar o vetor de movimento
    //Andando em cada tecla e seus valores, negativo para esquerda e para baixo, positivo para direita e para cima. Copiei a linha do W e só mudei valores.

    //if (Input.GetKey(KeyCode.W))
    //{
    //move = new Vector3(0, 0, 1);
    //move = transform.forward;
    //}

    //if (Input.GetKey(KeyCode.S))
    //{
    //move = new Vector3(0, 0, -1);
    //essa linha abaixo é esse calculo: "move= new vector3(Mathf.Sin (ang*Mathf.Deg2Rad), 0 , Mathf.Cos (ang * mathf.Deg2Rad));" isso é por um calculo matematico para fazer a rotação em relação a sua virada, a seu angulo, a linha abaixo resume todo esse calculo.
    //move = -transform.forward;
    //}

    //if (Input.GetKey(KeyCode.D))
    //{
    //move = transform.right; //andar para direita.
    //rot = new Vector3(0, 1, 0);
    //}

    //if (Input.GetKey(KeyCode.A))
    //{
    //move = -transform.right; //andar para a esquerda.
    //rot = new Vector3(0, -1, 0);
    //}

    //rot.y = Input.GetAxis("Mouse X");


    //chtr.SimpleMove(move);
    //transform.Rotate(rot);
    //move = Vector3.zero;
    //rot = Vector3.zero;

    //}
}