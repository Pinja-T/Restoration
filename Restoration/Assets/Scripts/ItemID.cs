using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemID : MonoBehaviour
{
    public string ID;
    [SerializeField] PickUp pickUpScript;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Ground")
        {
            //pickUpScript.Drop();
        }
            
    }
}
