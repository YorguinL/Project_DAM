using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    private int rows = 15;
    private int cols = 25;
    private float tileSize = 0.85f;
    public GameObject gridPrefab;


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateGrid(){

        GameObject referenceTile = (GameObject)Instantiate(gridPrefab);

        for (int row = 0; row < rows; row++){
            for(int col = 0; col < cols; col++){

                GameObject tile = (GameObject)Instantiate(referenceTile, transform);
                 
                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2(posX, posY);

            }
        }
        Destroy(referenceTile);
        float gridW = cols * tileSize;
        float gridH = rows * tileSize;
        transform.position = new Vector2(0,0);
    }
}
