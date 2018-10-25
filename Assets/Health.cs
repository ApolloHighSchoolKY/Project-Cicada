using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public GameObject self;
    public int life;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BGB(Clone)")
            life -= 1;
        else if (other.gameObject.name == "RB(Clone)")
            life -= 5;
        if (life <= 0)
            self.SetActive(false);
        other.gameObject.SetActive(false);
    }   
}
