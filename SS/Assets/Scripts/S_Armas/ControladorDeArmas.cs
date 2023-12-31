using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeArmas : MonoBehaviour
{
    public GameObject[] Armas;
    private int contador;
    public GameObject[] Select;

    private void Awake()
    {
        contador = 0;
    }

    public void Start()
    {
        
    }

    private void Update()
    {
        TrocarArma();
        ArmaEscolhida();
    }

    public void TrocarArma()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            contador++;
            
        }
    }

    public void ArmaEscolhida()
    {
        if (contador == 0)
        {
            Armas[0].gameObject.GetComponent<Arma1>().canShoot = true;
            Armas[1].gameObject.GetComponent<Arma2>().canShoot = false;
            Armas[2].gameObject.GetComponent<Arma3>().canShoot = false;
            
            Select[0].gameObject.SetActive(true);
            Select[1].gameObject.SetActive(false);
            Select[2].gameObject.SetActive(false);
        }

        if (contador == 1)
        {
            Armas[0].gameObject.GetComponent<Arma1>().canShoot = false;
            Armas[1].gameObject.GetComponent<Arma2>().canShoot = true;
            Armas[2].gameObject.GetComponent<Arma3>().canShoot = false;
            
            Select[0].gameObject.SetActive(false);
            Select[1].gameObject.SetActive(false);
            Select[2].gameObject.SetActive(true);
        }

        if (contador == 2)
        {
            Armas[0].gameObject.GetComponent<Arma1>().canShoot = false;
            Armas[1].gameObject.GetComponent<Arma2>().canShoot = false;
            Armas[2].gameObject.GetComponent<Arma3>().canShoot = true;
            
            Select[0].gameObject.SetActive(false);
            Select[1].gameObject.SetActive(true);
            Select[2].gameObject.SetActive(false);
        }

        if (contador > 2)
        {
            contador = 0;
        }
    }

}
