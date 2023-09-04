using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma3 : MonoBehaviour
{
    private float intervaloTiro;
    public float tempoEsperaTiro;
    public int maxTiros;
    public float tirosAtuais;
    public Transform localFirePoint;

    public GameObject laser;
    
    public bool canShoot;
    public bool descontar;

    public Text textoMunicao;
    
    public void Start()
    {
        tirosAtuais = maxTiros;
        intervaloTiro = 0;
        laser.SetActive(false);
        textoMunicao.text = tirosAtuais + "%";
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
                    if (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space))
                    {
                        laser.SetActive(true);
                        tirosAtuais -= Time.deltaTime * 10;
                        textoMunicao.text = tirosAtuais + "%";
                    }

                    if (Input.GetButtonUp("Fire1") || Input.GetKeyUp(KeyCode.Space))
                    {
                        laser.SetActive(false);
                    }
                }
                else
                {
                    laser.SetActive(false);
                }
            }
        }
    }

    public void GanharCarga(int municaoParaReceber)
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
}
