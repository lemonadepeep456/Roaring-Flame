using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UIElements.UxmlAttributeDescription;


public class EnemyChaseScript : MonoBehaviour
{
    public GameObject BlueCoin;
    public float spawnRadius = 0.5f;
    public Transform player;
    public PlayerMovementScript playerMovementScript;
    public HealthManager healthManager;
    public int enemyFacing;
    public float speed;
    public float distanceBetween;
    private float distance;
    public bool chase;
    public bool hitPlayer;
    public GameManagerScript gameManagerScript;

    public GameObject gameManagerScriptObject;
    public float separationDistance = 1.5f;
    public float separationStrength = 2f;
    public float attackDistance = 1.0f;


    public Animator zombieAnimator;

    // Physics variable addition
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the Rigidbody2D component attached to this zombie
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        gameManagerScriptObject = GameObject.FindWithTag("GameManager");
        gameManagerScript = Object.FindFirstObjectByType<GameManagerScript>();
        healthManager = Object.FindFirstObjectByType<HealthManager>();
        playerMovementScript = Object.FindFirstObjectByType<PlayerMovementScript>();

        hitPlayer = healthManager.hitPlayer;
    }

    // Update is called once per frame
    void Update()
    {
      
        {
            // Prevent errors if the player is missing
            if (player == null) return;

            distance = Vector2.Distance(transform.position, player.position);
            Vector2 direction = player.position - transform.position;
            direction.Normalize();

            // ---- FIX: Automatically determine enemyFacing based on player direction ----
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                // Moving mostly horizontally
                enemyFacing = direction.x > 0 ? 1 : -1; // 1 = Right, -1 = Left
            }
            else
            {
                // Moving mostly vertically
                enemyFacing = direction.y > 0 ? -2 : 2; // -2 = Back/Up, 2 = Front/Down
            }
            // ----------------------------------------------------------------------------

            if (distance < distanceBetween)
            {
                chase = true;

                // Move the enemy (Pulled out of the animation blocks so they ALWAYS move)
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                // Play correct chase animation
                if (enemyFacing == 1) GetComponent<Animator>().Play("ZombieRightRun");
                if (enemyFacing == -1) GetComponent<Animator>().Play("ZombieLeftRun");
                if (enemyFacing == 2) GetComponent<Animator>().Play("ZombieFrontRun");
                if (enemyFacing == -2) GetComponent<Animator>().Play("ZombieBackRun");
            }
            else
            {
                chase = false;

                // Play correct idle animation
                if (enemyFacing == 1) GetComponent<Animator>().Play("ZombieRightIdle");
                if (enemyFacing == -1) GetComponent<Animator>().Play("ZombieLeftIdle");
                if (enemyFacing == 2) GetComponent<Animator>().Play("ZombieFrontIdle");
                if (enemyFacing == -2) GetComponent<Animator>().Play("ZombieBackIdle");
            }
        }
    }
}



