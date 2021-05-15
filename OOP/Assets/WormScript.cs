using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormScript : Entity
{
    // Start is called before the first frame update
    void Start()
    {
        lives = 1;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject==Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives--;
            Debug.Log("Worm lives=" + lives);
        }
        if(lives<1)
            Die();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
