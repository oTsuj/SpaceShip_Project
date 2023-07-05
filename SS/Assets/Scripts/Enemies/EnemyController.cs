using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float tempoDecorrido;
    public Enemy1 cacaEstelar;
    
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
        if (tempoDecorrido >= 8f)
        {
            tempoDecorrido = 6f;

            Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            float posicaoY = Random.Range(posicaoMinima.y, posicaoMaxima.y);

            Vector2 posicaoInimigo = new Vector2(posicaoMaxima.x, posicaoY);
            
            Instantiate(this.cacaEstelar, posicaoInimigo, Quaternion.Euler(0, -180, 0));
        }
    }
    
}
