using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov3d : MonoBehaviour
{
    public float Speed;
    public Rigidbody rb;
    public LayerMask chao;
    public float ForcaDoPulo;
    public float alturaDoChao;
    //public float altura;
    public Animator anim;
    public bool Empulo;
    public bool Nochao;

    public GameObject LocalParticula;
    public GameObject Particula;
    public GameObject LocalBala;
    public GameObject Bala;

    Transform T;
    Transform camera;

    ControladorSom controleSom;

    private void Awake()
    {
        controleSom = GameObject.FindWithTag("MainCamera").GetComponent<ControladorSom>();
    }

    private void Start()
    {
        T = GetComponent<Transform>();
        camera = GameObject.FindWithTag("Tripe").GetComponent<Transform>();
    }
    void FixedUpdate()
    {

        //dados de movimentação
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");
        bool apertouPulo = Input.GetButtonDown("Jump");

        Vector3 mov = new Vector3(mH, 0, mV);

        //rotação
        T.LookAt(T.position + camera.TransformDirection(mov) * 2);

        if(mov.magnitude > 1f)
        {
            mov.Normalize();
        }

        T.Translate(0, 0, mov.magnitude * Speed * Time.deltaTime);

        RaycastHit chaoHit;
            Nochao = Physics.Raycast(T.position, Vector3.down, out chaoHit, alturaDoChao + 0.05f, chao);

        Empulo = apertouPulo || !Nochao;

        rb.useGravity = Empulo;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        if (!Empulo)
        {
            rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionY;
        }
        if (apertouPulo && Nochao)
        {
            rb.AddForce(Vector3.up * ForcaDoPulo, ForceMode.Impulse);
        }
        if (!Empulo) {
            RaycastHit hit;
                bool BateunoChao = Physics.Raycast(T.position, Vector3.down, out hit, Mathf.Infinity, chao);
            if (BateunoChao)
            {
                Vector3 pos = T.position;
                pos.y = hit.point.y + alturaDoChao;
                T.position = pos;
            }
            //para a inercia
            rb.velocity = Vector3.zero;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            //anim.SetTrigger("Atack");
            anim.SetBool("Attack", true);
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", false);
            anim.SetBool("Death", false);
            Instantiate(Particula, LocalParticula.transform.position, LocalParticula.transform.rotation);
        }
        if (Input.GetButton("Horizontal"))
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Idle", false);
            anim.SetBool("Death", false);
            anim.SetBool("Attack", false);
        }
        if (Input.GetButton("Vertical"))
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Idle", false);
            anim.SetBool("Death", false);
            anim.SetBool("Attack", false);
        }
        if (!Input.GetButton("Fire1") && !Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
            anim.SetBool("Death", false);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(Bala, LocalBala.transform.position, LocalBala.transform.rotation);
            Bala.GetComponent<Rigidbody>().AddForce(transform.forward * 3 * 10000);
            controleSom.Ouvir(ControladorSom.Toques.Explosao);
        }

    }
    
}
