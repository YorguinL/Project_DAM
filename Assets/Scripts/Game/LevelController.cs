using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject portalPrefab;

    public GameObject [] enemyPrefabs;

    int count = 0;
    
    public float spawnRate = 2f;

    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyPrefabs = new GameObject[3];
        enemyPrefabs = Resources.LoadAll ("/Prefabs/Enemy") as GameObject[];
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn){

            nextSpawn = Time.time + spawnRate;
            CreateEnemies();

        }
    }

    void levels(){

        switch(count){
            case(10):
                print("Nivel 1 superado!");
                break;
        }

    }

    void CreateEnemies(){

        int rnd = Random.Range(0,3);
        GameObject enemy = (GameObject)Instantiate(enemyPrefabs[rnd]);
        enemy.transform.position = portalPrefab.transform.position;
        count++;
    }

}
