using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Tank : MonoBehaviour
{
    //public GameObject Tank;
    GameObject a, b, d;
    public GameObject ExplesionEffect;
    public GameObject E2Bullet;
    public GameObject E2Rocket;
    public Transform player;
    Rigidbody2D rb;
    public int health = 40;
    public float moveSpeed = 100f;
    public float bulletSpeed = 100f;
    public float range = 35;
    public AudioClip[] sounds;
    int rs = 0;
    int delay = 0;
    int damage = 4;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("Aim1").gameObject;
        b = transform.Find("Aim2").gameObject;
        d = transform.Find("Rocket2Loc").gameObject;

    }
    void Update()
    {
        if (CheckRange())
        {
            MoveToEnemy();
            if (player.position.x - transform.position.x <= 0.4f && delay > 30)
            {
                Shoot();
                rs++;
            }
            else if (rs > 5)
            {
                ShootRocket();
                rs = 0;
            }
            delay++;
        }
    }

    void MoveToEnemy()
    {
        if (transform.position.x > player.transform.position.x)
        {
            //transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            rb.velocity = new Vector2(-moveSpeed * Time.deltaTime, -0.3f);
        }
        else if (transform.position.x < player.transform.position.x)
        {
            //transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            rb.velocity = new Vector2(moveSpeed * Time.deltaTime, -0.3f);
        }
    }

    bool CheckRange()
    {
        if (GameObject.Find("Tank") == null)
        {
            return false;
        }
        return transform.position.y - player.transform.position.y < range;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        GameObject explode = Instantiate(ExplesionEffect, transform.position, Quaternion.identity);
        Destroy(explode, 1.0f);
        Destroy(gameObject);
        GetComponent<AudioSource>().PlayOneShot(sounds[2]);
    }

    void Shoot()
    {
        delay = 0;
        GameObject b1 = Instantiate(E2Bullet, a.transform.position, Quaternion.identity);
        b1.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);

        GameObject b2 = Instantiate(E2Bullet, b.transform.position, Quaternion.identity);
        b2.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);

        GetComponent<AudioSource>().PlayOneShot(sounds[0]);
        damage = 8;
    }

    void ShootRocket()
    {
        GameObject rocket = Instantiate(E2Rocket, d.transform.position, Quaternion.identity);
        rocket.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);

        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<TankDrive>().Damage(damage);
        }
    }
}
