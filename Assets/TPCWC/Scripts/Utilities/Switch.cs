using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPCWC{
public class Switch : MonoBehaviour {

	[Header("-- Switch Properties --")]
	[Tooltip("Door which you want to send notification to")]
	public Door doorTarget;
	[Tooltip("Do you want to close door as soon as player exits this trigger")]
	public bool closeDoorOnExit;
	
	// Use this for initialization
	void Start () {
			
		if(!doorTarget)
			Debug.LogWarning("No Door Target Assigned at "+ name + ". Please ensure that you assign one for this " + name + " to work!");

	}
	
	void OnTriggerEnter(Collider c){

		//if player enters trigger
		if(c.tag == "Player")
		{	
			//if we have a door target
			if(doorTarget)
				//fire it's open event
				doorTarget.openDoor();
		}

	}

	void OnTriggerExit(Collider c){
		
		//if player enters trigger
		if(c.tag == "Player")
		{
			//if we have a door target
			if(doorTarget){
				if(closeDoorOnExit)
					//fire it's close event
					doorTarget.closeDoor();
			}
		}
	}
	
}
}