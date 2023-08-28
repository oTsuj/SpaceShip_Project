using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperTiro : MonoBehaviour
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
}
