using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser2 : MonoBehaviour
{
    public float laserVelocidade;
    public int dano = 50;
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
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            col.gameObject.GetComponent<Enemy1>().TakeDamage(dano);
            Destroy(this.gameObject);
        }
        
        if (col.gameObject.CompareTag("Inimigo1"))
        {
            col.gameObject.GetComponent<Enemy2>().TakeDamage(dano);
            Destroy(this.gameObject);
        }
        
        if (col.gameObject.CompareTag("Inimigo2"))
        {
            col.gameObject.GetComponent<Enemy3>().TakeDamage(dano);
            Destroy(this.gameObject);
        }
        
        if (col.gameObject.CompareTag("EscudoInimigo"))
        {
            col.gameObject.GetComponent<EscudoInimigo>().TakeDamage(dano);
            Destroy(this.gameObject);
        }
    }
}
