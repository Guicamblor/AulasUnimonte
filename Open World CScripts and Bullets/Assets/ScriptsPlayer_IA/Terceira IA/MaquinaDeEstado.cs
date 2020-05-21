using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaDeEstado : MonoBehaviour
{
    public bool EstadoPatrulha;
    public bool EstadoAtual;
    public bool EstadoAlerta, EstadoPerseguicao, EstadoInicial;

    //Visão

    public Transform Olhos;
    public float RaiodVi = 20f;
    public Vector3 VetorDDistancia = new Vector3(0f, 0.75f, 0f);
    private ControladorNavMesh controlador;

    // --------------------------

    //Estado Patrulha
    public Transform[] Waypoint;

    private int SeguirOsPontos;
    // --------------------------

    void Awake()
    {
        controlador = GetComponent<ControladorNavMesh>();
        AtivarEstados(EstadoInicial);
    }
    void Start()
    {
        
    }

    void Update()
    {
        //Estado Patrulha
        RaycastHit hit;
        if(VeOJogador(out hit))
        {
            controlador.target = hit.transform;
            AtivarEstados(EstadoPerseguicao = true);
            return;
        }

        if (controlador.Chegou())
        {
            SeguirOsPontos = (SeguirOsPontos + 1) % Waypoint.Length;
            AtualizarDestino();
        }
        // --------------------------
    }

    public void AtivarEstados(bool novoEstado)
    {
        EstadoAtual = false;
        EstadoAtual = novoEstado;
        EstadoAtual = true;

    }

    // --------------------------

    //Visão

    public bool VeOJogador(out RaycastHit hit, bool MiraTarget = false)
    {
        Vector3 direcao;
        if (MiraTarget)
        {
            direcao = (controlador.target.position + VetorDDistancia) - Olhos.position;
        }
        else
        {
            direcao = Olhos.forward;
        }
        //Faz a IA ver o jogador pelos Olhos
        return Physics.Raycast(Olhos.position, direcao, out hit, RaiodVi) && hit.collider.CompareTag("Player");
    }

    // --------------------------

    //Estado Patrulha
    void OnEnable()
    {
        SeguirOsPontos = 0;
        AtualizarDestino();
    }

    void AtualizarDestino()
    {
        controlador.AtualizarDestino(Waypoint[SeguirOsPontos].position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AtivarEstados(EstadoAlerta = true);
        }
    }
    // --------------------------

}
