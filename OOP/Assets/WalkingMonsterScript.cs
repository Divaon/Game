using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMonsterScript : Entity
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 3.5f;
    private Vector3 dir;
    private SpriteRenderer sprite;
    
        

    void Start()
    {
        dir = transform.right;
        lives = 1;
    }

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }


    public void OnCollisionEnter2D(Collision2D collision)
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
    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.7f, 0.001f);
        if (colliders.Length>0) dir *=-1f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed*Time.deltaTime);
        sprite.flipX = -dir.x < 0.0f;
    }




    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
