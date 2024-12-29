// Script que determina o movimento de um player em um game 3D na Unity:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controlador;
    private Transform minhaCamera;
    private Animator animator;
    public float velocidade = 2f;
    
    void Start()
    {
        controlador = GetComponent<CharacterController>();
        minhaCamera = Camera.main.transform;
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(horizontal, 0, vertical);
        movimento = minhaCamera.TransformDirection(movimento);
        movimento.y = 0;

        controlador.Move(movimento * Time.deltaTime * velocidade);
        controlador.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime);
      
        if (movimento!= Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimento), Time.deltaTime *10);
           
        }
        animator.SetBool("Move", movimento != Vector3.zero); Debug.Log(movimento);
    }
}