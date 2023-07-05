using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoInimigo : MonoBehaviour
{
    
    public int vidaMaxima = 50;
    private int vidaAtual;
    public int danoAoPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeDamage(int damage)
    {
        vidaAtual -= damage;
        if (vidaAtual <= 0)
        {
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
