using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmaBasica : MonoBehaviour
{
    
    public GameObject laserPlayer;
    private float intervaloTiro;
    public float tempoEsperaTiro;
    public bool tiroInfinito;
    public int maxTiros;
    public int tirosAtuais;
    public Transform[] localFirePoint;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        tirosAtuais = maxTiros;
        intervaloTiro = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.intervaloTiro += Time.deltaTime;
        if (this.intervaloTiro >= this.tempoEsperaTiro)
        {
            if (tiroInfinito)
            {
                if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
                {
                    intervaloTiro = 0;
                    ShootLaser();
                }
            }
            if(!tiroInfinito)
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
        //ShootLaser();
    }

    protected void CriarLaser(Vector2 posicao)
    {
        Instantiate(this.laserPlayer, posicao, Quaternion.identity);
    }
    
    //Tiro do Player
    protected abstract void ShootLaser();
}
