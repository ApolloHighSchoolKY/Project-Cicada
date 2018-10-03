using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    //Variable to store (r,g,b,a) values)
    byte rndR;
    byte rndG;
    byte rndB;
    byte rndA;
    // Use this for initialization
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //Sets variable to random vaule between 0 and 255
        rndR = (byte)Random.Range(0, 255);
        rndG = (byte)Random.Range(0, 255);
        rndB = (byte)Random.Range(0, 255);
        rndA = (byte)Random.Range(0, 255);
        
        //Changes color of object to the stored (r,g,b,a) values
        gameObject.GetComponent<Renderer>().material.color = new Color32(rndR, rndG, rndB, rndA);
    }
}
