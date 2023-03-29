using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    [SerializeField] string statueCode;
    public bool isStatueDone = false;
    private bool _sDone;
    GameMechanics gM;
    PickUp puS;

    // Start is called before the first frame update
    void Start()
    {
        puS = GameObject.Find("ItemHolder").GetComponent<PickUp>();
        gM = GameObject.Find("GameMechanic").GetComponent<GameMechanics>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            try
            {
                ItemID _ = other.GetComponent<ItemID>();
                if(_.ID == statueCode)
                {
                    CompleteStatue(other.gameObject);
                }
            }
            catch (System.Exception)
            {

                
            }
        }
    }

    void CompleteStatue(GameObject key)
    {
        puS.Drop();
        GameObject.Destroy(key,1);
        isStatueDone = true;
        _sDone = true;
        if (_sDone)
        {
            gM.i++;
        }
    }
}
