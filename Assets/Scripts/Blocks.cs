using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    Rigidbody2D rb;
    float health = 2;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Blocks")
        {
            collision.gameObject.GetComponent<TankDrive>().Damage(0);
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

    public void Damage()
    {
        if (health == 0)
            Destroy(gameObject);
    }
}
