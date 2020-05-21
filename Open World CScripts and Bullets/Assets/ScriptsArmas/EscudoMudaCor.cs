using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoMudaCor : MonoBehaviour
{
    public bool transparencia = false;
    public float Change = 1;
    Color CorRandom;
    Material mesh;
    float time;
    public float velocidadetroca = 3;
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>().material;
        time = 0;

        RandomizarCor();
    }
    private void OnCollisionEnter(Collision coli)
    {
        if (!coli.gameObject.CompareTag("Player"))
        {
            Destroy(GetComponent<Rigidbody>());
            transform.SetParent(coli.transform);
            Destroy(GetComponent<Blob>());
            Destroy(gameObject, 5);
        }
    }
    void RandomizarCor()
    {
        if (transparencia == true)
            CorRandom = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        else
            CorRandom = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);
    }
    void Update()
    {
        mesh.color = Color.Lerp(mesh.color, CorRandom, Time.deltaTime * velocidadetroca);
        time += Time.deltaTime;
        if (time > Change)
        {
            time = 0;
            RandomizarCor();
        }
    }
}
