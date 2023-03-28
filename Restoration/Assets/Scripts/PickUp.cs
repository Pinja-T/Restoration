using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool itemPicked = false;
    Rigidbody rb;
    Transform item;
    public float CooldownTime;
    float cooldownUntilNextPress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F) && cooldownUntilNextPress < Time.time)
        {
            if(!itemPicked)
            {
                RaycastHit hit;

                if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, 15f))
                {
                    Debug.Log(hit.transform.name);
                    if(hit.transform.tag == "Item")
                    {
                        PickUpItem(hit);
                    
                    }
                }
            }

            else
            {
                Drop();
            }

            cooldownUntilNextPress = Time.time + CooldownTime;
        }
    }

    public void Drop()
    {

        rb.isKinematic = false;
        item.parent = null;
        itemPicked = false;
    }

    public void PickUpItem(RaycastHit h)
    {
        rb = h.transform.GetComponent<Rigidbody>();
        item = h.transform;


        rb.isKinematic = true;
        item.parent = this.transform;
        StartCoroutine(LerpPosition(this.transform.position, 0.05f));
        itemPicked = true;
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = item.position;
        while (time < duration)
        {
            item.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        item.position = targetPosition;
    }
}
