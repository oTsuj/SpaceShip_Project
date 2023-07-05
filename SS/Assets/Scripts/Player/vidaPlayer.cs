using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaPlayer : MonoBehaviour
{
    public Slider barraDeVidaPlayer;
    
    public int maxVida;

    public int atualVida;

    public bool escudo;

    public int chances = 3;

    public Text textoChances;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        textoChances.text = "0" + chances + " x";
        
        atualVida = maxVida;
        barraDeVidaPlayer.maxValue = maxVida;
        barraDeVidaPlayer.value = atualVida;
    }

    // Update is called once per frame
    void Update()
    {
        RetirarChances();
    }

    public void DanoPlayer(int danoRecebido)
    {
        if (escudo == false)
        {
            atualVida -= danoRecebido;
            barraDeVidaPlayer.value = atualVida;
            
            Debug.Log(atualVida);
            
        }
    }

    public void RetirarChances()
    {
        textoChances.text = "0" + chances + " x";
        if (atualVida <= 0)
        {
            if (chances >= 0)
            {
                atualVida = maxVida;
                if (atualVida == maxVida)
                {
                    barraDeVidaPlayer.value = atualVida;
                    chances--;
                }
                
            }

            if (chances < 0)
            {
                chances = 0;
                //Destroy(this.player);
                Time.timeScale = 0;
            }
        }
    }
    
    
    
}
