using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    private float tempoDecorrido;
    public Enemy2 naveDeAtaque;
    
    // Start is called before the first frame update
    void Start()
    {
        tempoDecorrido = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CriarInimigo();
    }

    //Instanciando um Inimigo
    private void CriarInimigo()
    {
        tempoDecorrido += Time.deltaTime;
        if (tempoDecorrido >= 30f)
        {
            tempoDecorrido = 24;

            Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1f, 0.75f));
            Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0.25f));

            float posicaoY = Random.Range(posicaoMinima.y, posicaoMaxima.y);

            Vector2 posicaoInimigo = new Vector2(posicaoMaxima.x, posicaoY);
            
            Instantiate(this.naveDeAtaque, posicaoInimigo, Quaternion.Euler(0, -180, 0));
        }
    }
}
