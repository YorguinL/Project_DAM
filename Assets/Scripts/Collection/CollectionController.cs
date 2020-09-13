using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{

    private int killsForNewItems = 7;

    private int kills;

    public GameObject [] itemsPrefabs = new GameObject [3];

    // Start is called before the first frame update
    void Start()
    {
        itemsPrefabs = Resources.LoadAll<GameObject>("Prefabs/Collection");
        kills = GameController.countKilledEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        kills = GameController.countKilledEnemies;
        if(kills != 0){

            if(kills % killsForNewItems == 0){
                CreateItems();
            }

        } 
    }

    void CreateItems(){

        GameObject fireRateItem = (GameObject)Instantiate(itemsPrefabs[0]);
        PositionsController.NewPosition(fireRateItem);

        GameObject healthItem = (GameObject)Instantiate(itemsPrefabs[1]);
        PositionsController.NewPosition(healthItem);

        GameObject speedItem = (GameObject)Instantiate(itemsPrefabs[2]);
        PositionsController.NewPosition(speedItem);

    }
}
