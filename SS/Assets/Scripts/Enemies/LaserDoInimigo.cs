using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class LaserDoInimigo : MonoBehaviour
{

    public float velLaser;
    public float tempoVida;
    public int danoAoPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, tempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        movLaser();
    }

    private void movLaser()
    {
        transform.Translate(Vector3.left * (velLaser * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<vidaPlayer>().DanoPlayer(danoAoPlayer);
            Destroy(this.gameObject);
        }
    }
}
