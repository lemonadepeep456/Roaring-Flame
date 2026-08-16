using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CoinAnimScript : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public GameManagerScript gameManagerScript;
    public bool Collection;
    public bool GoldCoin;
    public bool BlueCoin;
    public int BlueCoinCounter;
    public int GoldCoinCounter;
    // Start is called before the first frame update
    void Start()
    {
        Collection = true;
        GoldCoinCounter = 0;
        BlueCoinCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (BlueCoin == true && Collection == false)
        {
            GetComponent<Animator>().Play("BlueCoin");
        }
        if (GoldCoin == true && Collection == false)
        {
            GetComponent<Animator>().Play("GoldCoin");
        }
       
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && BlueCoin == true)
        {
            if (Collection == true)
            {
                StartCoroutine(ActivateForSeconds(0.5f));
                gameManagerScript.IncreaseValueByOneGold();
            }
            IEnumerator ActivateForSeconds(float seconds)
            {
                Collection = true;
                GetComponent<Animator>().Play("BlueCoinCollection");
                yield return new WaitForSeconds(seconds);
                BlueCoinCounter++;
               



            }
    }
        if (collision.gameObject.tag == "Player" && GoldCoin == true)
        {
            if (Collection == true)
            {
                StartCoroutine(ActivateForSeconds(0.5f));
                gameManagerScript.IncreaseValueByOneGold();
            }
            IEnumerator ActivateForSeconds(float seconds)
            {
                Collection = true;
                GetComponent<Animator>().Play("GoldCoinCollection");
                yield return new WaitForSeconds(seconds);
                GoldCoinCounter++;
               

            }

        }
    }
}
