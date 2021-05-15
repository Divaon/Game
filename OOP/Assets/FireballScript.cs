using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : Entity
{

    Rigidbody2D rb;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        lives = 1;
    }

    private void FixedUpdate()
    {
        if (sprite.flipX == false)
            rb.AddForce(-transform.right * 2, ForceMode2D.Force);
        else if (sprite.flipX == true)
            rb.AddForce(transform.right * 2, ForceMode2D.Force);
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
        Die();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
