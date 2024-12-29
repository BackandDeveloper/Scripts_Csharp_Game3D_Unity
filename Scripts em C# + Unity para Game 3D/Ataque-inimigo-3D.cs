// Script em C#, para um inimigo realizar seu ataque em game 3D na Unity:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueInimigo : MonoBehaviour
{
    public int dano = 10;
    public float alcanceAtaque = 2f;
    public LayerMask camadaJogador;
    public Transform pontoDeAtaque;
    private bool isOnCooldown = false;
    public float cooldownTempo = 1.5f;
    private Animator animador;

    void Start()
    {
        animador = GetComponent<Animator>();
    }

    void Update()
    {
        VerificarAtaque();
    }

    void VerificarAtaque()
    {
        Collider[] jogadoresAcertados = Physics.OverlapSphere(pontoDeAtaque.position, alcanceAtaque, camadaJogador);
        foreach (Collider jogador in jogadoresAcertados)
        {
            if (!isOnCooldown)
            {
                StartCoroutine(Atacar(jogador));
            }
        }
    }

    IEnumerator Atacar(Collider jogador)
    {
        isOnCooldown = true;
        animador.SetTrigger("Attack");
        jogador.GetComponent<Player>().ReceberDano(dano);
        yield return new WaitForSeconds(cooldownTempo);
        isOnCooldown = false;
    }

    void OnDrawGizmosSelected()
    {
        if (pontoDeAtaque == null)
            return;

        Gizmos.DrawWireSphere(pontoDeAtaque.position, alcanceAtaque);
    }
}
