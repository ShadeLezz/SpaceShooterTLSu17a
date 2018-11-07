using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dmg;
    public float speed = 20f;
    public Rigidbody2D rb;


    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Enemy")
        {
            col.SendMessageUpwards("TakeDamage", dmg);
            Destroy(gameObject);
        }
    }
}
