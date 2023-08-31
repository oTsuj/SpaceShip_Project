using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarSuperTiro : MonoBehaviour
{
    public Transform localDisparo;
    public GameObject tiro;

    public void Atirar()
    {
        Instantiate(tiro, localDisparo.position, localDisparo.rotation);
    }
}
