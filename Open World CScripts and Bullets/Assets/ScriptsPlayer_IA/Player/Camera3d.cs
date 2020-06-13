using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3d : MonoBehaviour
{
    public Transform Jogador;
    public Transform Camera;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }
    void FixedUpdate()
    {
        Camera.position = Jogador.position;

        float mX = Input.GetAxis("Mouse X");
        Camera.Rotate(0, mX, 0);
        
    }
}
