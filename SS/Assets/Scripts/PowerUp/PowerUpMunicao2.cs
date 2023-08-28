using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMunicao2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Arma3>().GanharCarga(10);
        Destroy(this.gameObject);
    }
}
