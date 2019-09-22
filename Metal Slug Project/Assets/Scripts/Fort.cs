using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fort : MonoBehaviour {

    public float hp;
    public float damage;
    public bool isDead;
    public HealthPlayer playerHP;
    BoxCollider2D colliderFort;

	// Use this for initialization
	void Start () {
        colliderFort = GetComponent<BoxCollider2D>();
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "AttackFort")
        {
            TookDamage();
        }    
    }

    public void Die()
    {
        playerHP.canRevive = false;
    }

    private void TookDamage()
    {
        if (hp == 0)
        {
            Die();
            isDead = true;
            colliderFort.enabled = false;
        }
        else
        {
            hp -= damage;

        }


    }
}
