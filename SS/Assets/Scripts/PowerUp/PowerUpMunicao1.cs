using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMunicao1 : MonoBehaviour
{

    public int mun = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            
            Arma2 arma = other.GetComponentInChildren<Arma2>();
            arma.tirosAtuais = arma.maxTiros;
            Destroy(this.gameObject); 
        }
        
    }
}
