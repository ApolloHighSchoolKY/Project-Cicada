using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public GameObject self;
    public int startingLife;
	// Use this for initialization
	void Start ()
    {
        startingLife = GetComponent<Health>().life;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            self.GetComponent<Health>().life = startingLife;
            self.SetActive(true);
        }
    }
}
