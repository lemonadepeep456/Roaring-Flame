using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLootScript : MonoBehaviour
{
    public GameObject player;
    public GameObject Chest;
    public GameObject gameManager;
    public GameObject GoldCoin;
    public GameManagerScript gameManagerScript;
    public float spawnRadius = 0.5f;
    public int minCoins = 10;
    public int maxCoins = 20;
    public bool Collection;
    //public bool goldCoin;
    public int GoldCoinCounter;
    // Start is called before the firstame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        gameManager = GameObject.FindWithTag("GameManager");
        gameManagerScript = Object.FindFirstObjectByType<GameManagerScript>();
     //   GoldCoin = GameObject.FindWithTag("GoldCoin");
      //  Chest = GameObject.FindWithTag("Chest");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyAndSpawnChest(GameObject Chest)
    {
        Debug.Log("DestroyAndSpawn was called!");

        // Ensure the prefab is assigned before running any loops
        if (GoldCoin == null)
        {
            Debug.LogError("GoldCoin prefab is missing...");
            Destroy(Chest); // <--- THIS destroys the chest immediately!
            return;
        }

        // 2. Pick a random number between minCoins and maxCoins
        // Note: Random.Range for integers is exclusive of the max number, 
        // so we add +1 to make maxCoins inclusive.
        int randomCoinAmount = Random.Range(minCoins, maxCoins + 1);

        // 3. Loop through and spawn each coin individually
        for (int i = 0; i < randomCoinAmount; i++)
        {
            // Get the Chest position
            Vector3 spawnPos = Chest.transform.position;

            // Give each individual coin its own unique random offset
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            spawnPos += new Vector3(randomOffset.x, randomOffset.y, 0);

            // Spawn the coin
            Instantiate(GoldCoin, spawnPos, Quaternion.identity);
        }

        // 4. Destroy the enemy object
        Destroy(Chest);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object we hit is tagged "Enemy"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Pass the enemy's game object into our function
            DestroyAndSpawnChest(gameObject);
            Debug.Log("Chest Despawned!");
        }
    }



}