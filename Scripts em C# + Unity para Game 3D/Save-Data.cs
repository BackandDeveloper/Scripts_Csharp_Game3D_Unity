// Script para salvar o progresso em um Game 2D, e 3D na Unity:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{

    public float vidaJogador = 100f;
    public bool podeSalvar = false;

    private Vector3 ultimaPosicaoSalva;
    private float ultimaVidaSalva;
    private bool temDadosSalvos = false;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}