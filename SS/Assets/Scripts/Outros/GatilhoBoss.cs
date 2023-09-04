using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatilhoBoss : MonoBehaviour
{
    public Transform objetoAlvo;
    
    public float novaPosicaoY;

    public GameObject EC1;
    public GameObject EC2;
    public GameObject EC3;

    private void Start()
    { 
        //Transform posAtual = objeto.transform;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            EC1.SetActive(false);
            EC2.SetActive(false);
            EC3.SetActive(false);
            
            Vector3 posicaoAtual = objetoAlvo.position;

            // Define a nova posição no eixo Y
            posicaoAtual.y = novaPosicaoY;

            // Move o objeto para a nova posição
            objetoAlvo.position = posicaoAtual;
            
        }
    }
}
