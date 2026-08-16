using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public bool hitPlayer;
    public bool Attacking;
    //AudioManager audioManager;

    public SpriteRenderer playerSr;
    public PlayerMovementScript playerMovementScript;
    // Start is called before the first frame update
    public void ChangeHealth(int amount)
    {
        // health = maxHealth;
        health += amount;

    }
    void Start()
    {
        maxHealth = 3;
        Attacking = playerMovementScript.Attacking;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health >= 0)
        {
            playerSr.enabled = false;
            playerMovementScript.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (hitPlayer == true && Attacking == false)
        {
           // audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
           // audioManager.PlaySFX(audioManager.hurt);
            health -= 1;
            hitPlayer = false;
            Debug.Log("Player hit once!");
        }



        if (health == 0)
        {
            playerSr.enabled = false;
            playerMovementScript.enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            hitPlayer = true;
        }
    }
}
