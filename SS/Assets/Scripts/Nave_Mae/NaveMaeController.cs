using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NaveMaeController : MonoBehaviour
{
    public int danoAoPlayer;
    
    public GameObject laserInimigo;
    public GameObject laserInimigo2;
    public GameObject laserInimigo3;
    public Transform localDisparo;
    
    public float fireRate = 0.5f;
    public float anguloDisparo = 180f;
    private float proximoDisparo;
    public float intervaloDeTiro = 2f;
    
    private float tempo;

    public float maxHealth = 1000f;
    public float currentHealth;

    private float velX;
    
    public float amplitude; 
    public float frequency;
    
    private Vector3 startPosition;
    private float minY;
    private float maxY;
    
    public int pontosInimigo;

    public GameObject escudoInimgo;
    public bool escudo;
    public float maxVidaEscudo;
    public float vidaAtualEscudo;

    public bool estagio1;
    public bool estagio2;
    public bool estagio3;

    public Slider barraDeVidaBoss;

    
    // Start is called before the first frame update
    void Start()
    {
        tempo = intervaloDeTiro;
        
        proximoDisparo = Time.time + fireRate;
        
        currentHealth = maxHealth;
        
        startPosition = transform.position;
        
        Camera gameCamera = Camera.main;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        vidaAtualEscudo = maxVidaEscudo;

        estagio1 = false;
        estagio2 = false;
        estagio3 = false;

        barraDeVidaBoss.maxValue = maxHealth;
        barraDeVidaBoss.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        MovEnemy();
        
        AlternarModos();
        
        CompVida();
    }
    
    
    //Movimentar Inimigo
    private void MovEnemy()
    {
        //transform.Translate(Vector3.left * -velX * Time.deltaTime);

        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        
        newY = Mathf.Clamp(newY, minY + 0.7f, maxY - 0.7f);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    
    //Colidir com Laser
    public void TakeDamage(float damage)
    {
        if (escudo == false)
        {
            currentHealth -= damage;
            barraDeVidaBoss.value = currentHealth;
            if (currentHealth <= 0)
            {
                GameManager.Instance.AdicionarPontos(pontosInimigo);

                Destroy(gameObject);
            }
        }
        else
        {
            vidaAtualEscudo -= damage;

            if (vidaAtualEscudo <= 0)
            {
                escudoInimgo.SetActive(false);
                escudo = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<vidaPlayer>().DanoPlayer(danoAoPlayer);
        }
        
    }
    
    private void Shoot()
    {
        if (Time.time >= proximoDisparo)
        {
            float randomAngle = Random.Range(-anguloDisparo / 2f, anguloDisparo / 2f);
            Quaternion rotation = Quaternion.Euler(0f, 180f, randomAngle);
            Instantiate(laserInimigo, localDisparo.position, localDisparo.rotation * rotation);
            proximoDisparo = Time.time + fireRate;
        }
        
    }

    private void Shoot2()
    {
        tempo -= Time.deltaTime;

        if (tempo <= 0f)
        {
            GameObject laser2 = Instantiate(laserInimigo3, localDisparo.position, localDisparo.rotation);
            tempo = intervaloDeTiro;
        }
    }
    
    private void Shoot3()
    {
        tempo -= Time.deltaTime;

        if (tempo <= 0f)
        {
            GameObject laser1 = Instantiate(laserInimigo2, localDisparo.position, Quaternion.identity);
            tempo = intervaloDeTiro;
        }
    }

    public void AlternarModos()
    {
        if (estagio1)
        {
            Shoot();
        }

        if (estagio2)
        {
            Shoot2();
        }

        if (estagio3)
        {
            Shoot3();
        }
    }

    public void CompVida()
    {
        if (currentHealth > 5000)
        {
            estagio1 = true;
            estagio2 = false;
            estagio3 = false;
        }
        
        if (currentHealth < 5000 && currentHealth > 2000)
        {
            estagio1 = false;
            estagio2 = true;
            estagio3 = false;
        }
        
        if (currentHealth < 2000)
        {
            estagio1 = false;
            estagio2 = false;
            estagio3 = true;
        }
    }
    
}
