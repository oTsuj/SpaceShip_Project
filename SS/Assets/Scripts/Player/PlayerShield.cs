using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] 
    [Tooltip("Dano antes de desativar")]
    private int protecaoMax;

    private int protecaoAtual;

    public void Ativar()
    {
        this.protecaoAtual = protecaoMax;
        this.gameObject.SetActive(true);
    }

    public void Desativar()
    {   
        this.gameObject.SetActive(false);
    }

    public bool Ativo
    {
        get
        {
            return this.gameObject.activeSelf;
        }
    }

    public void ReceberDano()
    {
        this.protecaoAtual--;
        if (this.protecaoAtual <= 0)
        {
            Desativar();
        }
    }
}
