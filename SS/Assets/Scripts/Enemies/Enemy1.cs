using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy1 : MonoBehaviour
{

    public Rigidbody2D rig;
    public float velMax;
    public float velMin;
    public int danoAoPlayer;
    public float lerp = 100f;
    
    public int vidaMaxima = 50;
    private int vidaAtual;

    private float velX;
    private Transform target;

    private int posRandom;

    public int pontosInimigo;
    
    // Start is called before the first frame update
    void Start()
    {
        velX = Random.Range(velMax, velMin);
        vidaAtual = vidaMaxima;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        posRandom = Random.Range(5, -5);
    }

    // Update is called once per frame
    void Update()
    {
        MovEnemy();
    }
    
    
    //Mover inimigo
    private void MovEnemy()
    {
        //rig.velocity = new Vector2(-velX , 0);
        if (rig.position.x > target.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, velX * Time.deltaTime);
        }
        else
        {
            if (rig.position.x <= target.position.x)
            {
                rig.velocity = new Vector3(-velX , posRandom, lerp * Time.deltaTime);
            }
        }
        //transform.position = Vector2.MoveTowards(transform.position, target.position, velX * Time.deltaTime);
    }
    
    //Colidir com Laser
    public void TakeDamage(int damage)
    {
        vidaAtual -= damage;
        if (vidaAtual <= 0)
        {
            GameManager.instance.AdicionarPontos(pontosInimigo);
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<vidaPlayer>().DanoPlayer(danoAoPlayer);
        }
        
    }
}
