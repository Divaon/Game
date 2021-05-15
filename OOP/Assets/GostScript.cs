using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GostScript : Entity
{
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    [SerializeField] public float distance=1;
    [SerializeField] public float maxdist;
    [SerializeField] public float mindist;
    public int speed = 1;
    float starty;
    private Vector3 pos;


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        lives = 1;
        maxdist = transform.position.x;
        maxdist += 2;
        mindist = transform.position.x;
        mindist -= 2;
        Debug.Log(maxdist);
        Debug.Log(mindist);
        starty = transform.position.y;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives--;
            Debug.Log("Gost lives=" + lives);
        }
        if (lives < 1)
            Die();
    }



    private void FixedUpdate()
    
    {
        transform.Translate(transform.right * speed * Time.deltaTime/2);
        if (transform.position.x > maxdist)
        {
            speed = -speed;
            sprite.flipX = false;
        }
        else
        if (transform.position.x < mindist)
        {
            speed = -speed;
            sprite.flipX = true;
        }
    }

}
