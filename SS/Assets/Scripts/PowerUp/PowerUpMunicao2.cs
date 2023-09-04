using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpMunicao2 : MonoBehaviour
{
    public int mun = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Arma3 arma = other.GetComponentInChildren<Arma3>();
            
            arma.GanharCarga(mun);
            arma.textoMunicao.text = arma.tirosAtuais.ToString();
            Destroy(this.gameObject);
        }
        
    }
}
