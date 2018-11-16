using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPCWC{

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour {

	[Header("Door Animations")]
	[Tooltip("Door Open animation name")]
	public string doorOpenAnimation;
	[Tooltip("Door Close animation name")]
	public string doorCloseAnimation;
	
	[Tooltip("if false, door opens automatically")]
	public bool needKey;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider c){

		//if player enters this door's trigger
		if(c.tag == "Player"){

			//if we don't need key
			if(!needKey){

				//fire event to open the door
				openDoor();
			}
		}

	}

	//open door event
	public void openDoor(){
		
		//play animation
		GetComponent<Animator>().Play(doorOpenAnimation);

		//disable all colliders
		Collider[] cols = GetComponents<BoxCollider>();
				foreach(Collider col in cols){
					col.enabled = false;
		}	
	}

	//close door event
	public void closeDoor(){
		
		//play animation
		GetComponent<Animator>().Play(doorCloseAnimation);

		//enable all colliders back!
		Collider[] cols = GetComponents<BoxCollider>();
				foreach(Collider col in cols){
					col.enabled = true;
		}

	}
		
}
}