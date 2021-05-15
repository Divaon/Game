using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpforce = 7f;
    [SerializeField] public bool isGrounded = true;


    [SerializeField]  public bool isAttacing = false;
    [SerializeField] public bool isRecharged = true;
    public Transform attackpos;
    public float attackrange;
    public LayerMask enemy;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private GameObject Hero1;

    public static Hero Instance { get; set; }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpos.position, attackrange);
    }
    public override void GetDamage()
    {
        transform.position = new Vector3(-7,-2,0);
        lives = lives - 1;
        Debug.Log(lives);
        if (lives < 1)
            Die();
    }

    private void Attack()
    {
        if(isRecharged && isGrounded)
        {
            isAttacing = true;
            isRecharged = false;
            StartCoroutine(AttackAnimation());
            StartCoroutine(AttackCoolDown());

        }
    }

    private void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackpos.position, attackrange, enemy);
        for(int i=0; i<colliders.Length; i++)
        {
            colliders[i].GetComponent<Entity>().GetDamage();
        }
    }

    //Start

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent <SpriteRenderer>();
        anim = GetComponent<Animator>();
        Instance = this;
        isRecharged = true;
    }

    private void Run()
    {
        //rb.velocity = new Vector2(rb.velocity.x * speed*5, rb.velocity.y);
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }


    private void Jump()
    {
        anim.SetInteger("Anim", 2);
        rb.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }



    private void FixedUpdate()
    {
      //  if(Input.GetAxis("Horizontal")!=0)
        //    anim.SetInteger("Anim", 1)

    }

    // Update is called once per frame
    void Update()
    {
       // rb.velocity = new Vector2(Input.GetAxis("Horizontal"), speed);
        if ( (Input.GetAxis("Horizontal")>0 || Input.GetAxis("Horizontal") < 0))
        {
            anim.SetInteger("Anim", 1);
            Run();
        }
        if ( Input.GetAxis("Horizontal")==0)
        {
            anim.SetInteger("Anim", 0);
        }
        if (Input.GetAxis("Horizontal") >= 0)
        {
            sprite.flipX = false;
        }
        else 
        {
            sprite.flipX = true;
        }
        if ( isGrounded==true && Input.GetButtonDown("Jump"))
                Jump();
        if (Input.GetButtonDown("Fire1"))
        {
            OnAttack();
            Attack();
        }
    }

    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        isAttacing = false;
    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(1f);
        isRecharged = true;
    }


}
