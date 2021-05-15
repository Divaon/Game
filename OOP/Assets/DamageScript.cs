using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DamageScript : Entity
{
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {;
        Instance = this;
    }


    public static DamageScript Instance { get; set; }

    public virtual void GetDamage()
    {
        lives = 1;
    }


    void Update()
    {

        Invoke("Die", 0.7f);

    }


}
