using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTiro : MonoBehaviour
{
    public Transform localDisparo;
    public GameObject tiro;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(tiro, localDisparo.position, localDisparo.rotation);
        Destroy(this.gameObject);
    }
}
