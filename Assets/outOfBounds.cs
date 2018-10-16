using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outOfBounds : MonoBehaviour
{
    public Vector3 startPos;
	// Use this for initialization
	void Start ()
    {
        startPos = transform.position; // Marks start position
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(gameObject.transform.position.y <= -20)
            transform.position = startPos;
    }
}
