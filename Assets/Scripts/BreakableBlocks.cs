using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlocks : MonoBehaviour
{
    Rigidbody2D rb;
    public float health=2;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BreakableBlocks")
        {
            collision.gameObject.GetComponent<TankDrive>().Damage(0);
            Die();
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Damage(int damage)
    {
        health-=damage;
        if (health < 0)
            Die();
    }
}
