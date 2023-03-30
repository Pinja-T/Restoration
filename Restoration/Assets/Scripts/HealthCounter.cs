using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    //Collider object of darkness
    public Collider darkness;
    //Text to show how much health player has
    //public TMP_Text healthText;
    [SerializeField] Slider hpbar;
    //Amount of health player has
    public float health;
    public bool isAlive = true;
    //Is the player in the darkness
    public bool inDark;
    //How much players health is taken
    public float darknessSize;
    [SerializeField] float damageMod;
    public bool isTimeSlowed = false;

    //Time to slow down the lovering of players health
    public float time;
    //Time left in the timer
    private float timer;

    private float timer2;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        inDark = false;
        timer = time;
        timer2 = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTimeSlowed)
            {
                isTimeSlowed = false;
                Time.timeScale = 1;
            }
            else
            {
                isTimeSlowed = true;
                Time.timeScale = 0.65f;

            }
        }
        //Check the size of the darkness
        darknessSize = darkness.transform.localScale.x;
        //If player is in the darkness reduce health by a given amount and show health.
        if (inDark && timer == 0)
        {
            health -= darknessSize * damageMod;
            if (health > 0)
            {
                hpbar.value = health;
                //healthText.text = "Health: " + health;
            }
            else
            {
                health = 0;
                hpbar.value = health;
                //healthText.text = "Health: 0";
                isAlive = false;
                return;
            }

            timer = time;
        }
        else if (inDark && timer > 0)
        {
            timer -= 1;
        }

        // If player slows down time take damage:
        if (isTimeSlowed && timer2 == 0)
        {
            health -= 4;
            if (health > 0)
            {
                hpbar.value = health;
                //healthText.text = "Health: " + health;
            }
            else
            {
                health = 0;
                hpbar.value = health;
                //healthText.text = "Health: 0";
                isAlive = false;
                return;
            }

            timer2= time;
        }
        else if (isTimeSlowed && timer2> 0)
        {
            timer2-= 1;
        }
    }
}

