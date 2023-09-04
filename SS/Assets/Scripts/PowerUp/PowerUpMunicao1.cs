using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpMunicao1 : MonoBehaviour
{
    public int mun = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Arma2 arma = other.GetComponentInChildren<Arma2>();
            
            arma.GanharMunicao(10);
            arma.textoMunicao.text = arma.tirosAtuais.ToString();
            Destroy(this.gameObject);
        }
        
    }
}
