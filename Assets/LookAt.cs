using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    public Transform target;
    Quaternion straight;

    void Start()
    {

    }

    void Update()
    {
        if (target)
        {
            straight = target.transform.rotation;
            transform.rotation = straight;
        }
    }
}
