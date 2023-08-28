using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMunicao1 : MonoBehaviour
{
    public GameObject item;
    private void OnTriggerEnter2D(Collider2D other)
    {
        item.gameObject.GetComponent<Arma2>().GanharMunicao(10);
        Destroy(this.gameObject);
    }
}
