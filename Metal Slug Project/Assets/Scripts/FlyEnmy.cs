using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyEnmy : MonoBehaviour {

    public float duration;
    Rigidbody2D rb;
    public int damage = 10;
    public Vector2 basePosition;
    Vector2 basePositionX;
    public Vector2 direction;
    public Ease ease;
    public Fort fort;
    public Player player;

    public float moveSpeed;
    public float playerRange;
    public float distance;
    public bool facingRight = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        fort = GameObject.Find("Fort").GetComponent<Fort>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

     

    // Update is called once per frame
    void Update () {
        Vector2 FortPosX = new Vector2(fort.transform.position.x, transform.position.y);
        Vector2 PlayerPosX = new Vector2(player.transform.position.x, transform.position.y);

        if (fort.isDead == false)
        {
            distance = Vector2.Distance(transform.position, fort.transform.position);
            if (distance < playerRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, FortPosX, moveSpeed * Time.deltaTime);
            }
            if (transform.position.x > fort.gameObject.transform.position.x && facingRight)
            {

                Flip();
            }
            else if (transform.position.x < fort.gameObject.transform.position.x && !facingRight)
            {
                Flip();
            }
        }
        else
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < playerRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, PlayerPosX, moveSpeed * Time.deltaTime);
            }
            if (transform.position.x > player.gameObject.transform.position.x && facingRight)
            {

                Flip();
            }
            else if (transform.position.x < player.gameObject.transform.position.x && !facingRight)
            {
                Flip();
            }
        }
        
      

        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerRange);

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theFlip = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        transform.transform.eulerAngles = theFlip;
    }
}
