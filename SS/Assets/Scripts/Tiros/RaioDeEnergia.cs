using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaioDeEnergia : MonoBehaviour
{
    
    public float velocidadeTiro = 5f;
    private Transform jogador;
    public int danoAoPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        
        Vector2 direcao = (jogador.position - transform.position).normalized;
        float angle = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        transform.Translate(Vector2.right * velocidadeTiro * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Mova o tiro na direção do jogador
        transform.Translate(Vector2.right * velocidadeTiro * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<vidaPlayer>().DanoPlayer(danoAoPlayer);
            Destroy(this.gameObject);
        }
        
    }
}
