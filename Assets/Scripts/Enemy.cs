using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public float speed;
    public float deathDelay;

    public int damage;
    public int maxhealth;
    public int health;

    public Score score;

    // Use this for initialization
    void Start()
    {
        health = maxhealth;
        score = GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    virtual public void Update()
    {
        rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);

        if (health <= 0)
        {
            health = 0;
            Die(deathDelay);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.SendMessageUpwards("TakeDamage", damage);
            //Die(deathDelay);
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }

    public void Die(float delay)
    {
        speed = 0;
        Destroy(gameObject, delay);
        score.pts += 100;
    }
}
