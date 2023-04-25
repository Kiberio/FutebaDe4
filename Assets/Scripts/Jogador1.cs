using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jogador1 : MonoBehaviour
{
 private Rigidbody rb;
 public float velocidade = 5.0f;
 public float limiteDireita = 10.0f;
 public float limiteEsquerda = -10.0f;

  private void Start() {
    rb = GetComponent<Rigidbody>();
  } 
    private void FixedUpdate() {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        Vector3 velocidadeAtual = rb.velocity;
        velocidadeAtual.z = movimentoHorizontal * velocidade;
        rb.velocity = velocidadeAtual;

        Vector3 posicaoAtual = transform.position;
        posicaoAtual.z = Mathf.Clamp(posicaoAtual.z, limiteEsquerda, limiteDireita);
        transform.position = posicaoAtual;
    }
}
