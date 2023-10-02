using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text textoPontuacao;

    public int inimigosDerrotados;

    [SerializeField] private string Menu;
    [SerializeField] private string GUI;
    [SerializeField] private string Fase1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.GameObject());
        }
        else
        {
            Destroy(this.GameObject());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(Menu);
        inimigosDerrotados = 0;
        textoPontuacao.text = "Pontos: " + inimigosDerrotados;
    }

    public void ChamarCenas()
    {
        SceneManager.LoadScene(GUI);
        SceneManager.LoadScene(Fase1, LoadSceneMode.Additive);
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
