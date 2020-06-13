using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulo : MonoBehaviour
{
    public Transform tr;
    public Rigidbody rb;
    public float deslocamentoAltura;
    public float intensidadePulo;
    public LayerMask CamadaChao;
    public bool estaEmPulo;
    public bool estaNoChao;

    private void FixedUpdate()
    {
        bool apertouPulo = Input.GetButtonDown("Jump");
        RaycastHit chaoHit;
        estaNoChao = Physics.Raycast(tr.position, Vector3.down, out chaoHit, deslocamentoAltura + 0.05f, CamadaChao);

        estaEmPulo = apertouPulo || !estaNoChao;

        rb.useGravity = estaEmPulo;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        if (!estaEmPulo)
        {
            rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionY;
        }
        if (apertouPulo && estaNoChao)
        {
            rb.AddForce(Vector3.up * intensidadePulo, ForceMode.Impulse);
        }
    }
}
