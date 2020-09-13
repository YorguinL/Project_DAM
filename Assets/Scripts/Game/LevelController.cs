using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject portalPrefab;

    public GameObject [] enemyPrefabs;

    int count = 0;
    
    public float spawnRate;

    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        levels(1);

    }

    void levels(int lvl){

        switch(lvl){
            case(1):
                spawnRate = 7f;
                PortalController.time = 30f;
                if(count < 15){
                    CreateEnemies();
                }
            break;

            case(2):
                spawnRate = 3f;
                PortalController.time = 20f;
                if(count < 20){
                    CreateEnemies();
                }
            break;

            case(3):
                spawnRate = 3.5f;
                PortalController.time = 15f;
                if(count < 15){
                    CreateEnemies();
                }
            break;

            case(4):
                spawnRate = 2f;
                PortalController.time = 10f;
                if(count < 20){
                    CreateEnemies();
                }
            break;

            case(5):
                spawnRate = 2f;
                PortalController.time = 10f;
                if(count < 20){
                    CreateEnemies();
                }
            break;

            case(6):
                spawnRate = 1f;
                PortalController.time = 5f;
                if(count < 20){
                    CreateEnemies();
                }
            break;
        }

    }

    void CreateEnemies(){
    
        if(Time.time > nextSpawn){
            nextSpawn = Time.time + spawnRate;
            int rnd = Random.Range(0,3);
            GameObject enemy = (GameObject)Instantiate(enemyPrefabs[rnd]);
            enemy.transform.position = portalPrefab.transform.position;
            count++;
        }

    }

}
