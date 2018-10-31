using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject player;
    private GameObject currentlyHeld;
    private GameObject pickUp;
    private Vector3 swap;

    private void Start()
    {
        currentlyHeld = GameObject.Find("Burst Gun");
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Gun" && collision.gameObject != currentlyHeld && Input.GetKeyDown("e"))
        {

            pickUp = collision.gameObject;
            swap = pickUp.transform.position;

            pickUp.GetComponent<CapsuleCollider>().enabled = false;
            pickUp.GetComponent<MeshCollider>().enabled = false;
            pickUp.GetComponent<ShootScript>().enabled = true;
            pickUp.transform.parent = player.transform;
            pickUp.GetComponent<Rigidbody>().useGravity = false;


            currentlyHeld.GetComponent<CapsuleCollider>().enabled = true;
            currentlyHeld.GetComponent<MeshCollider>().enabled = true;
            currentlyHeld.GetComponent<ShootScript>().enabled = false;
            currentlyHeld.transform.parent = null;
            currentlyHeld.GetComponent<Rigidbody>().useGravity = true;

            pickUp.transform.rotation = currentlyHeld.transform.rotation;
            pickUp.transform.position = currentlyHeld.transform.position;
            currentlyHeld.transform.position = swap;

            currentlyHeld = pickUp;


        }
    }
}
