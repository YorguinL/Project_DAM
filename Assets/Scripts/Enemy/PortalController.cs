using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public float time = 10f;
    float nextPosition = 0.0f;
    public Transform portal;

    // Start is called before the first frame update
    void Start()
    {
        NewPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextPosition){
            nextPosition = Time.time + time;
            NewPosition();
        }
    }


    void NewPosition(){

        int rnd = Random.Range(0,2);
        
        if(rnd == 0){
            NewPositionLeft();
        } else {
            NewPositionRight();
        }
    }

    void NewPositionLeft(){
        int posX = Random.Range(-4,-17);
        int posY = Random.Range(-8,8);

        print(posX);
        print(posY);

        transform.position = new Vector3(posX, posY, 0);
    }
    void NewPositionRight(){
        int posX = Random.Range(4,17);
        int posY = Random.Range(-8,8);

        print(posX);
        print(posY);

        transform.position = new Vector3(posX, posY, 0);
    }
}
