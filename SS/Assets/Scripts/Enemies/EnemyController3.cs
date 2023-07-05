using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController3 : MonoBehaviour
{
    private float tempoDecorrido;
    public Enemy3 cruzadorDeBatalha;
    
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
        if (tempoDecorrido >= 60f)
        {
            tempoDecorrido = 52;

            Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1f, 0.60f));
            Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0.40f));

            float posicaoY = Random.Range(posicaoMinima.y, posicaoMaxima.y);

            Vector2 posicaoInimigo = new Vector2(posicaoMaxima.x, posicaoY);
            
            Instantiate(this.cruzadorDeBatalha, posicaoInimigo, Quaternion.Euler(0, -180, 0));
        }
    }
}
