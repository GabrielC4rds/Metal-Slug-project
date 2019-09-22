using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;

    public float speed = 5;
    public bool facingRight = true;
    
    //Ground Variables
    public float jumpHeight = 12;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;
    private bool grounded;
    //Shoot Variables
    public float timeToDestroy;
    public GameObject bullets;
    public Transform barrel;
    public float bulletSpeed;
    public GameObject bullet;
    //Other Scripts
    HealthPlayer hp;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hp = GetComponent<HealthPlayer>();
    }
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if(hp.isDead == false)
        {

            //Move
            float moveX = Input.GetAxis("Horizontal");
            anim.SetFloat("moveX", Mathf.Abs (moveX));
            rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
            //Jump
            if (Input.GetButtonDown("Jump") && grounded)
            {
                Jump();
            }
            //Shoot
            if (Input.GetButtonDown("Shoot"))
            {
                Shoot();

            }
            //Flip
            if (moveX > 0 && !facingRight)
            {
                Flip();
            }
            else if (moveX < 0 && facingRight)
            {
                Flip();
            }
            if (grounded)
            {
                anim.SetBool("onGround", true);
            }
            else
            {
                anim.SetBool("onGround", false);
            }
        }

    }


    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theFlip = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        transform.eulerAngles = theFlip;
    }
    public void Shoot()
    {
        bullet = (GameObject)Instantiate(bullets, barrel.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        anim.SetTrigger("shootTrigger");
        StartCoroutine(Some());


    }

    IEnumerator Some()
    {
        GameObject bulletIn;
        bulletIn = bullet;
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(bulletIn);
    }

    
}
