using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    private static int health = 6;

    private static int maxHealth = 6;

    private static float moveSpeed = 2f;

    private static float fireRate = 1f;

    private static int countAuxHT = 0;

    public static int countKilledEnemies = 0;
    public static int level = 0;
    public static int score = 0;

    public static int Health { get => health; set => health = value;}

    public static int MaxHealth { get => maxHealth; set => maxHealth = value;}

    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value;}

    public static float FireRate { get => fireRate; set => fireRate = value;}

    public Text healtItems;
    public Text fireRateItems;
    public Text speedItems;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        
        if(instance == null) {
            instance = this;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        healtItems.text = " x " + PlayerController.countHealth;
        fireRateItems.text = " x " + PlayerController.countFireRate;
        speedItems.text = " x " + PlayerController.countPlayerSpeed;

    }

    // Subtract damage from player
    public static void DamagePlayer(int damage) {

        health -= damage;

        if(health <= 0){
            
            calScore();
        }

    }

    public static void IncreaseHealth(int healthItems){
        if(health < maxHealth){
            if(healthItems > countAuxHT)
                health += 1;
        }
        countAuxHT = healthItems;
    }

    public static void IncreaseFireRate(int fireRateItems){

        switch(fireRateItems){

            case(3):
                fireRate = 0.85f;
            break;

            case(6):
                fireRate = 0.70f;
            break;

            case(18):
                fireRate = 0.55f;
            break;

            case(32):
                fireRate = 0.30f;
            break;
        }
    }

    public static void IncreasePlayerSpeed(int speedItems){

        switch(speedItems){

            case(3):
                moveSpeed = 2.5f;
            break;

            case(6):
                moveSpeed = 2.75f;
            break;

            case(18):
                moveSpeed = 3f;
            break;

            case(32):
                moveSpeed = 3.5f;
            break;
        }
    }

    public static void IncreaseLevel(){
        level = 1;
    }

    public static void calScore(){

        score = (PlayerController.countHealth * 2) + (PlayerController.countFireRate * 2) + (PlayerController.countPlayerSpeed * 2) + (countKilledEnemies + 5);
        
    }

}
