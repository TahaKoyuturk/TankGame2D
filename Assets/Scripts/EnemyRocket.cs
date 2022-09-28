using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0, -25);
        Destroy(gameObject, 1.1f);

    }
    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<TankDrive>().Damage(4);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "BreakableBlocks")
        {
            col.gameObject.GetComponent<BreakableBlocks>().Damage(4);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Blocks")
        {
            col.gameObject.GetComponent<Blocks>().Damage();
            Destroy(gameObject);
        }
    }
}
