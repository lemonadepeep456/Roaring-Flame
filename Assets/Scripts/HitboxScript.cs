using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    public bool leftOn;
    public bool rightOn;
    public bool upOn;
    public bool downOn;
    public int minCoins = 1;
    public int maxCoins = 5;
    public bool On;
    public GameObject BlueCoin;
    public float spawnRadius = 0.5f;
    public PlayerMovementScript playerMovementScript;
    public HealthManager healthManager;
    public GameObject player;
    public bool hitbox;
    void Start()
    {
        leftOn = false;
        rightOn = false;
        upOn = false;
        downOn = false;
        On = false;
        hitbox = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (On == true)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            StartCoroutine(ActivateForSeconds(0.5f));
            hitbox = false;


        }
        if (On == false)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        IEnumerator ActivateForSeconds(float seconds)
        {
            hitbox = false;
            yield return new WaitForSeconds(seconds);
            playerMovementScript.Attacking = false;
            playerMovementScript.canMove = true;
            On = false;


        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object we hit is tagged "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Pass the enemy's game object into our function
            DestroyAndSpawnEnemy(collision.gameObject);
            Debug.Log("Killed Enemy!");
        }
    }

    // Accept the enemy GameObject as a parameter
    public void DestroyAndSpawnEnemy(GameObject enemy)
    {
        Debug.Log("DestroyAndSpawn was called!");

        // Ensure the prefab is assigned before running any loops
        if (BlueCoin == null)
        {
            Debug.LogError("BlueCoin prefab is missing from the Inspector slot!");
            Destroy(enemy);
            return;
        }

        // 2. Pick a random number between minCoins and maxCoins
        // Note: Random.Range for integers is exclusive of the max number, 
        // so we add +1 to make maxCoins inclusive.
        int randomCoinAmount = Random.Range(minCoins, maxCoins + 1);

        // 3. Loop through and spawn each coin individually
        for (int i = 0; i < randomCoinAmount; i++)
        {
            // Get the enemy's base position
            Vector3 spawnPos = enemy.transform.position;

            // Give each individual coin its own unique random offset
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            spawnPos += new Vector3(randomOffset.x, randomOffset.y, 0);

            // Spawn the coin
            Instantiate(BlueCoin, spawnPos, Quaternion.identity);
        }

        // 4. Destroy the enemy object
        Destroy(enemy);
    }
}