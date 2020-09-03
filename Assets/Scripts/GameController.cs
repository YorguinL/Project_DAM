using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    private static int health = 6;

    private static int maxHealth = 6;

    private static float moveSpeed = 2.5f;

    private static float fireRate = 1f;

    public static int Health { get => health; set => health = value;}

    public static int MaxHealth { get => maxHealth; set => maxHealth = value;}

    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value;}

    public static float FireRate { get => fireRate; set => fireRate = value;}

    public Text vidorra;

    public Text collectedItems;

    public Text collectedFireRate;
    
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
        vidorra.text = "Vida: " + health; // Prueba
        collectedItems.text = "Health: " + PlayerController.countHealth;
        collectedFireRate.text = "FireRate: " + PlayerController.countFireRate;
    }

    // Subtract damage from player
    public static void DamagePlayer(int damage) {

        health -= damage;

    }

    public static void HealPlayer(int healAmount) {
        health = Mathf.Min(maxHealth, health + healAmount);
    }
}
