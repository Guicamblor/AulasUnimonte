using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string cena;
    public Transform Retorno;
    public int id;

    public static bool Retornar;
    static int idRetorno;

    public bool AtivarRetornar;

    Color transparente = new Color(0, 0, 0, 0);

    void Start()
    {
        Time.timeScale = 1;
        if (Retornar && id == idRetorno)
        {
            GameObject jogador = GameObject.FindGameObjectWithTag("Player");
            Transform TransJ = jogador.GetComponent<Transform>();
            TransJ.position = Retorno.position;
            TransJ.rotation = Retorno.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(AtivarRetornar)
            Retornar = true;

            Time.timeScale = 0;
            idRetorno = id;
            StartCoroutine(CarregarCena());
        }
    }

    IEnumerator CarregarCena()
    {
        Fade fade = FindObjectOfType<Fade>();
        fade.IniciarTransicao(transparente, Color.black);
        yield return new WaitUntil(() => fade.acabou);
        SceneManager.LoadScene(cena);
    }
}
