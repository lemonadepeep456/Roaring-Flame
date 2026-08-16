using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Texture emptyHeart;
    public Texture fullHeart;
    public RawImage[] hearts;
    public HealthManager healthManager;
    public VideoPlayer heartPlayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        health = healthManager.health;
        maxHealth = healthManager.maxHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].texture = fullHeart;
                //GetComponent<VideoPlayer>().Play();
                //Playvid
            }
            else
            {
                hearts[i].texture = emptyHeart;
                //etComponent<Animator>().Play("LostHeart");
                
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
