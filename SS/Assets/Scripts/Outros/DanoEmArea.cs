using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoEmArea : MonoBehaviour
{
    public int dano = 50;
    public float tempovida;

    public void Start()
    {
        Destroy(this.gameObject, tempovida);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            col.gameObject.GetComponent<Enemy1>().TakeDamage(dano);
        }
        
        if (col.gameObject.CompareTag("Inimigo1"))
        {
            col.gameObject.GetComponent<Enemy2>().TakeDamage(dano);
        }
        
        if (col.gameObject.CompareTag("Inimigo2"))
        {
            col.gameObject.GetComponent<Enemy3>().TakeDamage(dano);
        }
    }
}
