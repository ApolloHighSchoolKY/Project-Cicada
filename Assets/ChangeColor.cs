using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
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
        rndR = (byte)Random.Range(0, 255);
        rndG = (byte)Random.Range(0, 255);
        rndB = (byte)Random.Range(0, 255);
        rndA = (byte)Random.Range(0, 255);
        gameObject.GetComponent<Renderer>().material.color = new Color32(rndR, rndG, rndB, rndA);
    }
}