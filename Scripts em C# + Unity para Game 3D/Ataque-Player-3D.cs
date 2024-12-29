// Script que determina o ataque de um player em um game 3D na Unity:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public float alcanceAtaque = 2f;
    public int dano = 10;
    public LayerMask camadaInimigo;
    public Transform pontoDeAtaque;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Atacar();
        }
    }

    void Atacar()
    {
        animator.SetTrigger("Attack");

        Collider[] inimigosAcertados = Physics.OverlapSphere(pontoDeAtaque.position, alcanceAtaque, camadaInimigo);
        foreach (Collider inimigo in inimigosAcertados)
        {
            inimigo.GetComponent<Inimigo>().ReceberDano(dano);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (pontoDeAtaque == null)
            return;

        Gizmos.DrawWireSphere(pontoDeAtaque.position, alcanceAtaque);
    }
}
