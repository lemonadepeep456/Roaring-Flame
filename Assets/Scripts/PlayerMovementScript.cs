using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Vector3 upMoveForce;
    public Vector3 downMoveForce;
    public Vector3 leftMoveForce;
    public Vector3 rightMoveForce;
    public Vector3 jumpForce;
    public GameObject leftProjectilePrefab;
    public GameObject rightProjectilePrefab;
    public Vector3 leftProjectileOffset;
    public Vector3 rightProjectileOffset;
    public GameObject upProjectilePrefab;
    public GameObject downProjectilePrefab;
    public Vector3 upProjectileOffset;
    public Vector3 DownProjectileOffset;
    public Vector3 playerFacingRightOffset;
    public Vector3 playerFacingLeftOffset;
    public Vector3 playerFacingDownOffset;
    public Vector3 playerFacingUpOffset;
    public int playerFacing;
    public bool canJump;
    public bool canMove;
    public bool doubleJump;
    public bool Attacking;
    public float timer;
    public EnemyChaseScript enemyChaseScript;
    public GameManagerScript gameManagerScript;
    public GameObject blueCoin;
    public GameObject gameManagerObject;
    public GameObject swordLeft;
  
    public GameObject swordRight;
    public GameObject swordUp;
    public GameObject swordDown;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    AudioManagerScript audioManagerScript;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        canMove = true;
        Attacking = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Transform>().position += leftMoveForce * Time.deltaTime;
                GetComponent<Animator>().Play("KnightLeftRun");
                playerFacing = -1;
                enemyChaseScript.enemyFacing = -1;
                leftMoveForce.x = -5f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Transform>().position += rightMoveForce * Time.deltaTime;
                GetComponent<Animator>().Play("KnightRightRun");
                playerFacing = 1;
                enemyChaseScript.enemyFacing = 1;
                rightMoveForce.x = 5f;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Transform>().position += upMoveForce * Time.deltaTime;
                GetComponent<Animator>().Play("KnightBackRun");
                playerFacing = -2;
                enemyChaseScript.enemyFacing = -2;
                downMoveForce.y = -5f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Transform>().position += downMoveForce * Time.deltaTime;
                GetComponent<Animator>().Play("KnightFrontRun");
                playerFacing = 2;
                enemyChaseScript.enemyFacing = 2;
                upMoveForce.y = 5f;
            }
            else if (playerFacing == -1)
            {
                GetComponent<Animator>().Play("KnightLeftIdle");
            }
            else if (playerFacing == 2)
            {
                GetComponent<Animator>().Play("KnightFrontIdle");
            }
            else if (playerFacing == 1)
            {
                GetComponent<Animator>().Play("KnightRightIdle");
            }
            else if (playerFacing == -2)
            {
                GetComponent<Animator>().Play("KnightBackIdle");
            }
        }
        if (canMove == true && Input.GetKey(KeyCode.LeftShift))
        {

            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Transform>().position += leftMoveForce * Time.deltaTime;
                GetComponent<Animator>().Play("KnightLeftRun");
                playerFacing = -1;
                leftMoveForce.x = -7f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Transform>().position += rightMoveForce * Time.deltaTime;
                GetComponent<Animator>().Play("KnightRightRun");
                playerFacing = 1;
                rightMoveForce.x = 7f;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Transform>().position += upMoveForce * Time.deltaTime;
                GetComponent<Animator>().Play("KnightBackRun");
                playerFacing = -2;
                downMoveForce.y = -7f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Transform>().position += downMoveForce * Time.deltaTime;
                GetComponent<Animator>().Play("KnightFrontRun");
                playerFacing = 2;
                upMoveForce.y = 7f;
            }
        }
    
            if (canMove == true && Input.GetKeyDown(KeyCode.E) && playerFacing == -1)
            {
                canMove = false;
                Attacking = true;
                GetComponent<Animator>().Play("AttackLeft");
                swordLeft.GetComponent<HitboxScript>().On = true;
            audioManagerScript = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
            audioManagerScript.PlaySFX(audioManagerScript.slash);
        }
            else if (canMove == true && Input.GetKeyDown(KeyCode.E) && playerFacing == 1)
             {
            canMove = false;
            Attacking = true;
            GetComponent<Animator>().Play("AttackRight");
                swordRight.GetComponent<HitboxScript>().On = true;
            audioManagerScript = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
            audioManagerScript.PlaySFX(audioManagerScript.slash);
        }
            else if (canMove == true && Input.GetKeyDown(KeyCode.E) && playerFacing == -2)
            {
            canMove = false;
            Attacking = true;
            GetComponent<Animator>().Play("AttackBack");
                swordUp.GetComponent<HitboxScript>().On = true;
            audioManagerScript = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
            audioManagerScript.PlaySFX(audioManagerScript.slash);
        }
            else if (canMove == true && Input.GetKeyDown(KeyCode.E) && playerFacing == 2)
            {
            canMove = false;
            Attacking = true;
            GetComponent<Animator>().Play("AttackFront");
                swordDown.GetComponent<HitboxScript>().On = true;
            audioManagerScript = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
            audioManagerScript.PlaySFX(audioManagerScript.slash);
        }

        }
    

            //    if (playerFacing == 1)
            //    {
            //    Instantiate(rightProjectilePrefab, GetComponent<Transform>().position + rightProjectileOffset,
            //    Quaternion.identity);
            //   }
            //     if (playerFacing == -1)
            //    {
            //   Instantiate(leftProjectilePrefab, GetComponent<Transform>().position + leftProjectileOffset,
            //   Quaternion.identity);
            //  }
            // if (GetComponent<Transform>().position.y <= -5f)
            // {
            // gameManagerObject.GetComponent<GameManagerScript>().playerLost = true;
            // Destroy(gameObject);
            //}
        
    



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GoldCoin")
        {
            Destroy(collision.gameObject);
            gameManagerScript.IncreaseValueByOneGold();

            audioManagerScript = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
            audioManagerScript.PlaySFX(audioManagerScript.coinpickup);
        }
        if (collision.gameObject.tag == "BlueCoin")
        {
            
            Destroy(collision.gameObject);
            gameManagerScript.IncreaseValueByOneBlue();
            audioManagerScript = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
            audioManagerScript.PlaySFX(audioManagerScript.coinpickup);
        }
        if (collision.gameObject.tag == "Chest")
        {
            Destroy(collision.gameObject);
            gameManagerScript.IncreaseValueByTripleGold();
        //    audioManagerScript = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
          //  audioManagerScript.PlaySFX(audioManagerScript.coinpickup);
        }
    }
}