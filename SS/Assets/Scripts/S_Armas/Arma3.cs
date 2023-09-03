using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma3 : MonoBehaviour
{
    public GameObject laserPlayer;
    private float intervaloTiro;
    public float tempoEsperaTiro;
    public int maxTiros;
    public int tirosAtuais;
    public Transform localFirePoint;
    
    public bool canShoot;
    
    public virtual void Start()
    {
        tirosAtuais = maxTiros;
        intervaloTiro = 0;
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
