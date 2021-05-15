using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasterScript : Entity
{
    public GameObject fireball;
    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        lives = 1;
        sprite = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            SpawnFirebalss();
    }



    void SpawnFirebalss()
    {
        Debug.Log("Strike Arrow");
        if (sprite.flipX == false)
        {
            fireball.GetComponent<SpriteRenderer>().flipX = false;
            Instantiate(fireball, new Vector2(10.36f, transform.position.y), Quaternion.identity);
        }

        else if (sprite.flipX == true)
        {
            fireball.GetComponent<SpriteRenderer>().flipX = true;
            Instantiate(fireball, new Vector2(11.85f, transform.position.y), Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives--;
            Debug.Log("Worm lives=" + lives);
        }
        if (lives < 1)
            Die();
    }


    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").transform.position.x < transform.position.x)
            sprite.flipX = false;
        else if (GameObject.Find("Player").transform.position.x > transform.position.x)
            sprite.flipX = true;
    }
}
