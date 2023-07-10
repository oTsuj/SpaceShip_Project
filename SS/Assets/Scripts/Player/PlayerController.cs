using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rig2D;

    public float shipVelocity;

    private Vector2 moviTecla;

    void Start()
    {
    }
    
    void Update()
    {
    }

    private void FixedUpdate()
    {
        MovPlayer();
    }

    //Movimento do Player
    private void MovPlayer()
    {
        moviTecla = new Vector2(Input.GetAxisRaw("Horizontal"), (Input.GetAxisRaw("Vertical")));
        rig2D.velocity = moviTecla.normalized * shipVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Inimigo1"))
        {
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Inimigo2"))
        {
            Destroy(other.gameObject);
        }
        
    }
}
