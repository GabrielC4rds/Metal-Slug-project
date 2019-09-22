using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour {

    public float health;
    public float damage;
    public bool isDead;
    public bool invencible;
    public bool canRevive;

    Animator anim;
    BoxCollider2D colliderPlayer;
    public SpriteRenderer playerSR;
    

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        colliderPlayer = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if (!invencible)
            {
                
                StartCoroutine(Knockback());
            }
            
            
        }
    }

    public void Die()
    {
        isDead = true;
        anim.SetTrigger("Dead 0");
    }
    public IEnumerator Knockback()
    {
        if (health <= 0)
        {
            Die();
        }

        health -= damage;

        playerSR.color = Color.red;

        playerSR.color = Color.grey;
        gameObject.layer = 13;
        playerSR.color = Color.white;
        yield return new WaitForSeconds(0.15f);
        playerSR.enabled = false;
        yield return new WaitForSeconds(0.15f);
        playerSR.enabled = true;
        yield return new WaitForSeconds(0.15f);
        playerSR.enabled = false;
        yield return new WaitForSeconds(0.15f);
        playerSR.enabled = true;
        yield return new WaitForSeconds(0.15f);
        playerSR.enabled = false;
        yield return new WaitForSeconds(0.15f);
        playerSR.enabled = true;
        gameObject.layer = 10;
        invencible = false;
        

    }
}
