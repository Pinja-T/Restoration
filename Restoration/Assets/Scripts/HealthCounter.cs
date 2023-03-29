using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthCounter : MonoBehaviour
{
    //Collider object of darkness
    public Collider darkness;
    //Text to show how much health player has
    public TMP_Text healthText;
    //Text to tell the player that the game is over
    public GameObject gameOver;
    //Amount of health player has
    private float health;
    public bool isAlive = true;
    //Is the player in the darkness
    public bool inDark;
    //How much players health is taken
    public float darknessSize;
    [SerializeField] float damageMod;

    //Time to slow down the lovering of players health
    public float time;
    //Time left in the timer
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        inDark = false;
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Check the size of the darkness
        darknessSize = darkness.transform.localScale.x;
        //If player is in the darkness reduce health by a given amount and show health.
        if (inDark && timer == 0)
        {
            health -= darknessSize * damageMod;
            if (health > 0)
            {
                healthText.text = "Health: " + health;
            }
            else
            {
                health = 0;
                healthText.text = "Health: 0";
                gameOver.SetActive(true);
                isAlive = false;
                return;
            }

            timer = time;
        }
        else if (inDark && timer > 0)
        {
            timer -= 1;
        }
    }
}

