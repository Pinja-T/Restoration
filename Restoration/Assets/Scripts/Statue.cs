using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    [SerializeField] string statueCode;
    public bool isStatueDone = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
        GameObject.Destroy(key);
        isStatueDone = true;
    }
}
