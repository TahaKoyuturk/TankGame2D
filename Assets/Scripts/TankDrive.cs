using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankDrive : MonoBehaviour
{

    GameObject a, b ,c;
    public GameObject blowingEffect;
    public GameObject rocket;
    public GameObject bullet;
    Rigidbody2D rb;
    public float speed;
    public int health = 10;
    private float range = 25f;
    int damage;
    int delay = 0, delay2 = 0;
    public AudioClip[] sounds;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("Aim").gameObject;
        b = transform.Find("Aim 2").gameObject;
        c = transform.Find("Aim 3").gameObject;
    }
    void Update()
    {
        
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed , 0));
        rb.AddForce(new Vector2(0 ,Input.GetAxis("Vertical") * speed ));

        if (Input.GetKey(KeyCode.Space) && delay > 20)
            Shoot2();
        else if (Input.GetKey(KeyCode.LeftAlt) && delay2 > 150)
            Shoot();
        delay++;
        delay2++;
    }
    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject,2f);
            GameObject explode = Instantiate(blowingEffect, transform.position, Quaternion.identity);
            Destroy(explode, 1.5f);
            GetComponent<AudioSource>().PlayOneShot(sounds[2]);
            SceneManager.LoadScene(8);
        }
    }
    void OnLine()
    {

    }
    void Shoot2()
    {
        delay = 0;
        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);
        damage = 2;
        GetComponent<AudioSource>().PlayOneShot(sounds[0]);
    }

    void Shoot()
    {
        delay2 = 0;
        Instantiate(rocket, c.transform.position, Quaternion.identity);
        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
        damage = 4;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyTank>().Damage(damage);
        }
    }
}
