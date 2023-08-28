using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public int danoAoPlayer;
    
    public GameObject laserInimigo;
    public Transform localDisparo;
    public float fireRate = 0.5f;
    public float anguloDisparo = 60f;
    private float proximoDisparo;
    
    public float velMax;
    public float velMin;
    
    public int maxHealth = 100;
    private int currentHealth;

    private float velX;
    
    public float amplitude; 
    public float frequency;
    
    private Vector3 startPosition;
    private float minY;
    private float maxY;
    
    public int pontosInimigo;

    public int chanceDrop;
    public GameObject[] itemDrop;
    
    void Start()
    {
        proximoDisparo = Time.time + fireRate;
        
        velX = Random.Range(velMax, velMin);
        currentHealth = maxHealth;
        
        startPosition = transform.position;
        
        Camera gameCamera = Camera.main;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
    
    void Update()
    {
        MovEnemy();
        if (Time.time >= proximoDisparo)
        {
            Shoot();
            proximoDisparo = Time.time + fireRate;
        }
    }

    
    //Mover inimigo
    private void MovEnemy()
    {
        
        transform.Translate(Vector3.left * -velX * Time.deltaTime);

        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        
        newY = Mathf.Clamp(newY, minY + 0.5f, maxY - 0.5f);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        
    }
    
    //Colidir com laser
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            GameManager.instance.AdicionarPontos(pontosInimigo);

            int randomNum = Random.Range(0, 100);

            if (randomNum <= chanceDrop)
            {
                var drop = Random.Range(0, itemDrop.Length);
                Instantiate(itemDrop[drop], transform.position, Quaternion.Euler(0f, 0f, 0f));
            }

            Destroy(gameObject);
        }
    }
    
    private void Shoot()
    {
        float randomAngle = Random.Range(-anguloDisparo / 2f, anguloDisparo / 2f);
        Quaternion rotation = Quaternion.Euler(0f, 180f, randomAngle);
        Instantiate(laserInimigo, localDisparo.position, localDisparo.rotation * rotation);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<vidaPlayer>().DanoPlayer(danoAoPlayer);
        }
        
    }
    
}
