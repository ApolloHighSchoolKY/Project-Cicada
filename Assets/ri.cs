using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ri : MonoBehaviour {

    public Rigidbody rb; //Rigidbody to apply forces to
	//Variables to store force values in
	int x1;
    int y1;
    int z1;

    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    private void Update()
    {	
		//Generate random values for x,y,z axis forces
        x1 = Random.Range(-1500, 1500);
        y1 = Random.Range(-1500, 1500);
        z1 = Random.Range(-250, 1500);
    }
    void FixedUpdate ()
    {
		//Applies random forces to rigidbody
        rb.AddForce(x1*Time.deltaTime, y1*Time.deltaTime, z1* Time.deltaTime);
	}
}
