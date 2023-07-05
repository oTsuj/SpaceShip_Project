using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rig2D;
    public GameObject laserPlayer;
    public Transform lFirePoint;
    public bool laserD;
    //private int dano = 1;

    public float shipVelocity;

    private Vector2 moviTecla;

    private float distanceZ;
    private float leftBorder;
    private float rightBorder;
    private float topBorder;
    private float bottomBorder;


    void Start()
    {
        laserD = false;
    }
    
    void Update()
    {
        
        ShootLaser();
        //ManterNaTela();
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
    
    //Tiro do Player
    private void ShootLaser()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            if (laserD == false)
            {
                Instantiate(laserPlayer, lFirePoint.position, lFirePoint.rotation);
            }
        }
    }

    /*private void ManterNaTela()
    {
        distanceZ = (transform.position - Camera.main.transform.position).z;
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceZ)).x;
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).y;
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanceZ)).y;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
            transform.position.z
        );

    }*/

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
