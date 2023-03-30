using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] GameObject phint;
    public bool itemPicked = false;
    [SerializeField] GameObject Hands;
    Animator anim;
    Rigidbody rb;
    Transform item;
    public float CooldownTime;
    AudioSource pickUpSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = Hands.GetComponent<Animator>();
        StartCoroutine(stAnim());
        pickUpSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out RaycastHit _r, 15f))
        {
            if (_r.transform.tag == "Item" && !itemPicked) phint.SetActive(true);
            else phint.SetActive(false);
        }
        // && cooldownUntilNextPress < Time.time
        if (Input.GetKeyDown(KeyCode.F))
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

            
        }
    }
    private void FixedUpdate()
    {
        if (rb != null)
        {
            Vector3 nP = Vector3.Lerp(item.position, this.transform.position, Time.deltaTime * 2f);
            rb.MovePosition(nP);
        }
    }

    public void Drop()
    {
        if (!pickUpSource.isPlaying) pickUpSource.Play();
        rb.useGravity = true;
        rb = null;
        anim.SetTrigger("Drop");

        //rb.isKinematic = false;
        //item.parent = null;
        itemPicked = false;
        anim.SetBool("Holding", false);

    }

    public void PickUpItem(RaycastHit h)
    {
        if (!pickUpSource.isPlaying) pickUpSource.Play();
        rb = h.transform.GetComponent<Rigidbody>();
        item = h.transform;
        rb.useGravity = false;
        anim.SetTrigger("Pick Up");

        //rb.isKinematic = true;
        //item.parent = this.transform;
        //StartCoroutine(LerpPosition(this.transform.position, 0.1f));
        itemPicked = true;
        anim.SetBool("Holding", true);
    }

    IEnumerator stAnim()
    {
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("Start");
    }
}
