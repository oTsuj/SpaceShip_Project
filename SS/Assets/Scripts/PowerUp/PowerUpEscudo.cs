using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PowerUpEscudo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<vidaPlayer>().AtivarEscudo();
        Destroy(this.gameObject);
    }
}
