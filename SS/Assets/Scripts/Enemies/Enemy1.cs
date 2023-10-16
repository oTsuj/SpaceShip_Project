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
    
    public float vidaMaxima = 50;
    public float vidaAtual;

    private float velX;
    private Transform target;

    private int posRandom;

    public int pontosInimigo;
    
    public int chanceDrop;
    public GameObject[] itemDrop;

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
    }
    
    //Colidir com Laser
    public void TakeDamage(float damage)
    {
        vidaAtual -= damage;
        if (vidaAtual <= 0)
        {
            //GameManager.Instance.AdicionarPontos(pontosInimigo);
            
            int randomNum = Random.Range(0, 100);

            if (randomNum <= chanceDrop)
            {
                int drop = Random.Range(0, itemDrop.Length);
                Instantiate(itemDrop[drop], transform.position, Quaternion.Euler(0f, 0f, 0f));
            }
            
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
