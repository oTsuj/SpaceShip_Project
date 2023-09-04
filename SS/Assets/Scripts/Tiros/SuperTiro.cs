using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperTiro : MonoBehaviour
{
    public float laserVelocidade;
    public float tempovida ;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tempovida);
    }

    // Update is called once per frame
    void Update()
    {
        MooveLaser();
    }
    
    private void MooveLaser()
    {
        transform.Translate(Vector3.right * (laserVelocidade * Time.deltaTime));
    }

    private void OnDestroy()
    {
        DestruirInimigosNaTela();
    }

    public void DestruirInimigosNaTela()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
        GameObject[] inimigos1 = GameObject.FindGameObjectsWithTag("Inimigo1");
        GameObject[] inimigos2 = GameObject.FindGameObjectsWithTag("Inimigo2");
        
        foreach (GameObject inimigo in inimigos)
        {
            Destroy(inimigo);
        }
        
        foreach (GameObject inimigo1 in inimigos1)
        {
            Destroy(inimigo1);
        }
        
        foreach (GameObject inimigo2 in inimigos2)
        {
            Destroy(inimigo2);
        }
    }
}
