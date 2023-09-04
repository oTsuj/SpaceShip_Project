using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilNaveMae : MonoBehaviour
{
    
    public float lerp = 150f;
    private float velX;
    private Transform target;
    public Rigidbody2D rig;
    private int posRandom;
    public float velMax;
    public float velMin;
    
    public int danoAoPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        velX = Random.Range(velMax, velMin);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        posRandom = Random.Range(5, -5);
    }

    // Update is called once per frame
    void Update()
    {
        Mov();
        Rotacionar();
    }
    
    private void Mov()
    {
        if (rig.position.x > target.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, velX * Time.deltaTime);
        }
        else
        {
            if (rig.position.x <= target.position.x)
            {
                rig.velocity = new Vector3(-velX , posRandom, lerp * Time.deltaTime);
            }
        }
    }
    
    private void Rotacionar()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<vidaPlayer>().DanoPlayer(danoAoPlayer);
            Destroy(this.gameObject);
        }
        
    }
}
