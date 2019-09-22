using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public int level;
    int numberOfEnemies;
    public GameObject flyEnmyPrefab;
    public Transform spawn1, spwan2;

    // Use this for initialization
    void Start () {
		if(level == 1)
        {
            Level1();
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    void Level1()
    {
        numberOfEnemies = 5;
        StartCoroutine(InstantiateEnum());
    }

    IEnumerator InstantiateEnum()
    {
       
        for (int i = 0; i <= numberOfEnemies; i++)
        {
            yield return new WaitForSeconds(2);
            Instantiate(flyEnmyPrefab, spawn1.position, Quaternion.identity);
        }

    }
}
