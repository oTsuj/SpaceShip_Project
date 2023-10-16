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

    public GameObject posPlayer;
    [SerializeField] private GameObject player;

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
        //textoPontuacao.text = "Pontos: " + inimigosDerrotados;
    }

    public void ChamarCenas()
    {
        SceneManager.LoadScene(GUI);
        SceneManager.LoadSceneAsync(Fase1, LoadSceneMode.Additive).completed +=delegate(AsyncOperation operation) { InstanciarOPlayer(); };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdicionarPontos(int pontosGanhos)
    {
        inimigosDerrotados += pontosGanhos;
        PlayerObserverManager.PointsChanged(inimigosDerrotados);
        //textoPontuacao.text = "Pontos: " + inimigosDerrotados;
    }

    public void InstanciarOPlayer()
    {
        posPlayer = GameObject.FindGameObjectWithTag("LocalSpawn");
        Instantiate(player, posPlayer.transform.position, Quaternion.Euler(0, 0, 0));
        
        player.GetComponent<vidaPlayer>().PlayerReset();
    }
}
