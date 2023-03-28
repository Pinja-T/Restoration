using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteredDark : MonoBehaviour
{

    [SerializeField] HealthCounter counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Tells the program the player has entered the darkness
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            counter.inDark = true;

        }
    }

    //Tells the program that player has exited the darkness
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            counter.inDark = false;
        }
    }

}
