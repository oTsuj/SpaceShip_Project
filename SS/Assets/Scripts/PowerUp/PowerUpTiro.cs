using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTiro : MonoBehaviour
{
    //public Transform localDisparo;
    //public GameObject tiro;
    private AtivarSuperTiro AtivarSuperTiro;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<AtivarSuperTiro>().Atirar();
            Destroy(this.gameObject); 
        }
    }
}
