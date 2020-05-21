using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorNavMesh : MonoBehaviour
{
    public Transform target;


    private NavMeshAgent Agent;

    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
    public void AtualizarDestino(Vector3 Destino)
    {
        Agent.destination = Destino;
        Agent.Resume();
        AtualizarDestino(target.position);
    }
    void Parar()
    {
        Agent.Stop();
    }
    public bool Chegou()
    {
        return Agent.remainingDistance <= Agent.stoppingDistance && !Agent.pathPending;
    }
}
