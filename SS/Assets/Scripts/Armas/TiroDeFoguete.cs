using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroDeFoguete : ArmaBasica
{
    private Transform localDisparo;
    
    public override void Start()
    {
        base.Start(); //referencio a classe que esta sendo herdada
        this.localDisparo = this.localFirePoint[0];
    }

    // Update is called once per frame

    protected override void ShootLaser()
    {
        CriarLaser(this.localDisparo.position);
    }
}
