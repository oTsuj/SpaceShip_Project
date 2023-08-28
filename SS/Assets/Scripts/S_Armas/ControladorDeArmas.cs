using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeArmas : MonoBehaviour
{
    public GameObject[] Armas;
    private int contador;

    private void Update()
    {
        
    }

    public void TrocarArma()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            contador++;
            if (contador == 0)
            {
                
            }

            if (contador == 1)
            {
                
            }

            if (contador == 2)
            {
                
            }

            if (contador > 2)
            {
                contador = 0;
            }
        }
    }

}
