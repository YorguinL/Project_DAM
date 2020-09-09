using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{

    private int rows = 17;
    private int cols = 27;
    private float tileSize = 0.65f;
    public GameObject limitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLimits();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateLimits(){

        GameObject referenceTile = (GameObject)Instantiate(limitPrefab);

        // Linia superior
        for(int col = 0; col < cols; col++){
            GameObject tile = (GameObject)Instantiate(referenceTile, transform);
            float posX = col * tileSize;
            float posY = 0;
            tile.transform.position = new Vector2(posX, posY);
        }

        for (int col = 0; col <= cols; col++) {
            for(int row= 0; row < rows; row++){
                if(col == 0){
                    GameObject tile = (GameObject)Instantiate(referenceTile, transform);
                    float posX = col;
                    float posY = row * tileSize;
                    tile.transform.position = new Vector2(posX, posY);
                }

                if (col == (cols)){
                    GameObject tile = (GameObject)Instantiate(referenceTile, transform);
                    float posX = cols * tileSize;
                    float posY = row * tileSize;
                    tile.transform.position = new Vector2(posX, posY);
                }
            }    
        }

        // Linia inferior
        for (int col = 0; col < cols+1; col++){
            GameObject tile = (GameObject)Instantiate(referenceTile, transform);
            float posX = col * tileSize;
            float posY = rows * tileSize;
            tile.transform.position = new Vector2(posX, posY);          
        }
        Destroy(referenceTile);
        transform.position = new Vector2(0,0);
    }
}
