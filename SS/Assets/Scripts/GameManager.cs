using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text textoPontuacao;

    public int inimigosDerrotados;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        inimigosDerrotados = 0;
        textoPontuacao.text = "Pontos: " + inimigosDerrotados;
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdicionarPontos(int pontosGanhos)
    {
        inimigosDerrotados += pontosGanhos;
        textoPontuacao.text = "Pontos: " + inimigosDerrotados;
    }
}
