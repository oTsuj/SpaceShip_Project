using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArma : MonoBehaviour
{
    
    
    [SerializeField]
    private TiroRapido tiroRapido;
    
    [SerializeField]
    private TiroDeFoguete tiroDeFoguete;
    
    [SerializeField]
    private TiroLaser tiroLaser;

    [SerializeField]
    private ArmaPowerUp armaPowerUp;

    private ArmaBasica armaAtual;


    //Garante que todas as armas estejam desativadas antes do jogo começar
    private void Awake()
    {
        tiroRapido.Desativar();
        tiroDeFoguete.Desativar();
        tiroLaser.Desativar();
        armaPowerUp.Desativar();
    }


    //Arma selecionada
    public void EquiparTiroRapido()
    {
        this.ArmaAtual = this.tiroRapido;
    }
    
    
    public void EquiparTiroDeFoguete()
    {
        this.ArmaAtual = this.tiroDeFoguete;
    }
    
    
    public void EquiparTiroLaser()
    {
        this.ArmaAtual = this.tiroLaser;
    }
    
    public void EquiparArmaPowerUp()
    {
        this.ArmaAtual = this.armaPowerUp;
    }
    

    
    //Setar as armas ativas e desativar as outras
    private ArmaBasica ArmaAtual
    {
        set
        {
            if (this.armaAtual != null)
            {
                this.armaAtual.Desativar();
            }
            this.armaAtual = value;
            this.armaAtual.Ativar();
        }
    }
}
