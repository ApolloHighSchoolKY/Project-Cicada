using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public Rigidbody rb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{	
		//Causes object to violently rotate
		rb.transform.Rotate(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5));
	}
}
