using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaPowerUp : ArmaBasica
{
    private Transform localDisparo;

    //override = estou sobreescrevendo este metodo e desejo altera-lo de alguma forma
    public override void Start()
    {
        base.Start(); //referencio a classe que esta sendo herdada
        this.localDisparo = this.localFirePoint[0];
    }

    protected override void ShootLaser()
    {
        //Atirar o laser
        CriarLaser(this.localDisparo.position);
    }
}
