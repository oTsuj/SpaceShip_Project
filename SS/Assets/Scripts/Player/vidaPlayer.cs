using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UI;

public class vidaPlayer : MonoBehaviour
{
    public Slider barraDeVidaPlayer;
    public int maxVida;
    public int atualVida;

    public int chances = 3;
    public Text textoChances;

    public GameObject escudoPlayer;
    public bool escudo;
    public int maxVidaEscudo;
    public int vidaAtualEscudo;
    public float tempoMaximoEscudo;
    public float tempoAtualEscudo;
    
    void Start()
    {
        textoChances.text = "0" + chances + " x";
        
        PlayerReset();
    }
    
    void Update()
    {
        RetirarChances();
        RetirarTempoEscudo();
    }

    public void DanoPlayer(int danoRecebido)
    {
        if (escudo == false)
        {
            atualVida -= danoRecebido;
            barraDeVidaPlayer.value = atualVida;
            
            Debug.Log(atualVida);
            
        }
        else
        {
            vidaAtualEscudo -= danoRecebido;

            if (vidaAtualEscudo <= 0)
            {
                escudoPlayer.SetActive(false);
                escudo = false;
            }
        }
    }

    public void AtivarEscudo()
    {
        vidaAtualEscudo = maxVidaEscudo;
        
        escudoPlayer.SetActive(true);
        escudo = true;
    }

    public void DesativarEscudo()
    {
        escudoPlayer.SetActive(false);
        escudo = false;
        tempoAtualEscudo = tempoMaximoEscudo;
    }


    public void RetirarTempoEscudo()
    {
        if (escudo)
        {
            tempoAtualEscudo -= Time.deltaTime;

            if (tempoAtualEscudo <= 0)
            {
                DesativarEscudo();
            }
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

    public void PlayerReset()
    {
        atualVida = maxVida;
        //barraDeVidaPlayer.maxValue = maxVida;
        //barraDeVidaPlayer.value = atualVida;
        
        escudoPlayer.SetActive(false);
        escudo = false;
        tempoAtualEscudo = tempoMaximoEscudo;
        
        RetirarTempoEscudo();
    }
    
    
    
}
