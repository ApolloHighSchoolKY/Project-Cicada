using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Rigidbody rb;
    public Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - rb.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = rb.position + offset;
    }
}
