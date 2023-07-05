using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public int danoAoPlayer;
    
    public GameObject laserInimigo;
    public GameObject laserInimigo2;
    public Transform localDisparo;
    
    public float fireRate = 0.5f;
    public float anguloDisparo = 120f;
    private float proximoDisparo;
    public float intervaloDeTiro = 2f;
    
    private float tempo;
    
    public float velMax;
    public float velMin;
    
    public int maxHealth = 200;
    private int currentHealth;

    private float velX;
    
    public float amplitude; 
    public float frequency;
    
    private Vector3 startPosition;
    private float minY;
    private float maxY;
    
    public int pontosInimigo;

    
    // Start is called before the first frame update
    void Start()
    {
        tempo = intervaloDeTiro;
        
        proximoDisparo = Time.time + fireRate;
        
        velX = Random.Range(velMax, velMin);
        currentHealth = maxHealth;
        
        startPosition = transform.position;
        
        Camera gameCamera = Camera.main;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        MovEnemy();
        
        if (Time.time >= proximoDisparo)
        {
            Shoot();
            proximoDisparo = Time.time + fireRate;
        }

        Shoot2();
    }
    
    
    //Movimentar Inimigo
    private void MovEnemy()
    {
        transform.Translate(Vector3.left * -velX * Time.deltaTime);

        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        
        newY = Mathf.Clamp(newY, minY + 0.7f, maxY - 0.7f);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    
    //Colidir com Laser
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            GameManager.instance.AdicionarPontos(pontosInimigo);

            Destroy(gameObject);
        }
    }
    
    private void Shoot()
    {
        float randomAngle = Random.Range(-anguloDisparo / 2f, anguloDisparo / 2f);
        Quaternion rotation = Quaternion.Euler(0f, 180f, randomAngle);
        Instantiate(laserInimigo, localDisparo.position, localDisparo.rotation * rotation);
    }

    private void Shoot2()
    {
        tempo -= Time.deltaTime;

        if (tempo <= 0f)
        {
            GameObject laser1 = Instantiate(laserInimigo2, localDisparo.position, Quaternion.identity);
            GameObject laser2 = Instantiate(laserInimigo2, localDisparo.position, Quaternion.identity);
            tempo = intervaloDeTiro;
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
