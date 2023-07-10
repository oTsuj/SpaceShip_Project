using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJogo : MonoBehaviour
{

    private Transform player;
    public float lerp;
    
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 seguir = new Vector3(player.position.x + 8, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position , seguir, lerp * Time.deltaTime);
    }
    
    
    
}
