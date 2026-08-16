using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance { get; private set; }


    public float timer;
    public bool isGameOver;
    public bool playerWon;
    public bool playerLost;
    public CoinAnimScript[] coinAnimationScript;

    // --- Backing fields for the properties ---
    public int _blueCoin = 0;
    public int _goldCoin = 0;

    // --- C# Properties that auto-update the UI ---

    public int BlueCoin
    {
        get { return _blueCoin; }
        set
        {
            _blueCoin = value;
            if (blueCounterText != null)
                blueCounterText.text = _blueCoin.ToString();
        }
    }

    public int GoldCoin
    {
        get { return _goldCoin; }
        set
        {
            _goldCoin = value;
            if (goldCounterText != null)
                goldCounterText.text = _goldCoin.ToString();
        }
    }

    public TMP_Text blueCounterText;
    public TMP_Text goldCounterText;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the text display to 0 at the start of the game
        BlueCoin = 0;
        GoldCoin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void IncreaseValueByOneBlue()
    {
        // Automatically triggers the BlueCoin property and updates the UI
        BlueCoin++;
    }

    public void IncreaseValueByTripleBlue()
    {
        // Automatically triggers the BlueCoin property and updates the UI
        BlueCoin += 3;
    }

    public void IncreaseValueByOneGold()
    {
        // Automatically triggers the GoldCoin property and updates the UI
        GoldCoin++;
    }
    public void IncreaseValueByTripleGold()
    {
        GoldCoin += 3;
    }

}