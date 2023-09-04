using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser3 : MonoBehaviour
{
    public float dano = 1;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            col.gameObject.GetComponent<Enemy1>().TakeDamage(dano * Time.deltaTime);
        }
        
        if (col.gameObject.CompareTag("Inimigo1"))
        {
            col.gameObject.GetComponent<Enemy2>().TakeDamage(dano * Time.deltaTime);
        }
        
        if (col.gameObject.CompareTag("Inimigo2"))
        {
            col.gameObject.GetComponent<Enemy3>().TakeDamage(dano * Time.deltaTime);
        }
    }
}
