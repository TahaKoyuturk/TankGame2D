using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTank : MonoBehaviour
{
    //public GameObject Tank;
    public GameObject blowingEffect;
    public GameObject bullet;
    public GameObject Enemyrocket; 
    public Transform player;
    Rigidbody2D rb;
    int i = 0;
    int delay = 0;
    int damage = 3;
    public int health = 3;
    public float moveSpeed = 50f;
    public float bulletSpeed=100f;
    public float range = 25;
    public AudioClip[] sounds;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (CheckRange())
        {
            MoveToEnemy();
            if (player.position.x - transform.position.x <= 0.65f && delay > 25)
                Shoot();
            delay++;
        }
    }
    void MoveToEnemy()
    {

        if (transform.position.x > player.transform.position.x)
        {
            //transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            rb.velocity = new Vector2(-moveSpeed * Time.deltaTime, -0.5f);
        }
        else if (transform.position.x < player.transform.position.x)
        {
            //transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            rb.velocity = new Vector2(moveSpeed * Time.deltaTime, -0.5f);
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
        health-=damage;
        if (health <= 0)
            Die();
    }
    void Die()
    {
        GameObject explode = Instantiate(blowingEffect, transform.position, Quaternion.identity);
        Destroy(explode, 1.0f);
        Destroy(gameObject);
        GetComponent<AudioSource>().PlayOneShot(sounds[2]);
    }
    void Shoot()
    {
        
        delay = 0;
        if (i > 5)
        {
            i = 0;
            GameObject Bullett2 = Instantiate(Enemyrocket, transform.position, Quaternion.identity);
            Enemyrocket.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);
            GetComponent<AudioSource>().PlayOneShot(sounds[1]);
        }
        else
        {
            GameObject Bullett = Instantiate(bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);
            GetComponent<AudioSource>().PlayOneShot(sounds[0]);
        }
        i++;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<TankDrive>().Damage(damage);
        }
    }
}
