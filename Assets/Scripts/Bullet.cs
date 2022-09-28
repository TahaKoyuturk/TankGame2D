using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }
  
    void Update()
    {
        rb.velocity = new Vector2(0,30 );
        Destroy(gameObject, 0.8f);
       
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyTank>().Damage(2);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "BreakableBlocks")
        {
            col.gameObject.GetComponent<BreakableBlocks>().Damage(2);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Blocks")
        {
            col.gameObject.GetComponent<Blocks>();
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Boss")
        {
            col.gameObject.GetComponent<Boss>().Damage(2);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Enemy2")
        {
            col.gameObject.GetComponent<Enemy2Tank>().Damage(2);
            Destroy(gameObject);
        }
    }
}
