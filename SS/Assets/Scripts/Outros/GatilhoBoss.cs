using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoBoss : MonoBehaviour
{

    public GameObject EC1;
    public GameObject EC2;
    public GameObject EC3;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            EC1.SetActive(false);
            EC2.SetActive(false);
            EC3.SetActive(false);
        }
    }
}
