using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebaterBola : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movimento;
    public float forcaInicial = 250.0f;
    public float velocidade = 10.0f;

    private void Awake() {
       rb = GetComponent<Rigidbody>(); 
    }

    private void Start() {
        Vector3 direcao = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f)).normalized;
        rb.AddForce(direcao * forcaInicial);
    }

    void OnCollisionEnter(Collision collision) {
    // verifica se a bola colidiu com uma parede
     if (collision.gameObject.CompareTag("Parede")) {
        // inverte a velocidade da bola para rebatê-la
        GetComponent<Rigidbody>().velocity *= -5;
        velocidade = velocidade + 2;
     }
     if (collision.gameObject.CompareTag("Gol")){
        Destroy(gameObject);
     }
    }
    public void SetMovimento(InputAction.CallbackContext value){
        movimento = value.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        rb.AddForce(new Vector3(movimento.x,0,movimento.y) * Time.fixedDeltaTime * 300);
        Vector3 velocidadeAtual = rb.velocity.normalized * velocidade;
        rb.velocity = velocidadeAtual;
    }
}
