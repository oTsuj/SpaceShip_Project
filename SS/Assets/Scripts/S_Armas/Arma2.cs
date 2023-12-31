using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma2 : MonoBehaviour
{
    public GameObject laserPlayer;
    private float intervaloTiro;
    public float tempoEsperaTiro;
    public int maxTiros;
    public int tirosAtuais;
    public Transform localFirePoint;

    public GameObject armaSelecionada;
    public bool canShoot;
    
    public GameObject danoArea;

    public Text textoMunicao;
    
    public virtual void Start()
    {
        tirosAtuais = maxTiros;
        intervaloTiro = 0;
        textoMunicao.text = tirosAtuais.ToString();
    }

    private void Update()
    {
        if (canShoot)
        {
            this.intervaloTiro += Time.deltaTime;
            if (this.intervaloTiro >= this.tempoEsperaTiro)
            {
                if (tirosAtuais >= 1)
                {
                    if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
                    {
                        intervaloTiro = 0;
                        ShootLaser();
                        tirosAtuais--;
                        textoMunicao.text = tirosAtuais.ToString();
                        Console.WriteLine("Atirou");
                    }
                }
            }
        }
    }

    void ShootLaser()
    {
        Instantiate(laserPlayer, localFirePoint.position, localFirePoint.rotation);
    }

    public void GanharMunicao(int municaoParaReceber)
    {
        if (tirosAtuais + municaoParaReceber <= maxTiros)
        {
            tirosAtuais += municaoParaReceber;
        }
        else
        {
            tirosAtuais = maxTiros;
        }
    }

    public void Ativar()
    {
        armaSelecionada.SetActive(true);
    }
}
