using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPCWC{
	
	public class PushButton : MonoBehaviour {

		[Header("-- Push Button Properties --")]
		[Tooltip("Child transform to set the position and rotation of the player")]
		public Transform ikTarget;
		[Tooltip("Coordinate this event time with the push button animation!")]
		public float eventTime = 0.5f;
		[Tooltip("Target Door you want to sent a notification to!")]
		public Door doorTarget;

		[Header("-- Push Button Input --")]
		[Tooltip("Input button name which you have defined in Input Settings!")]
		public string inputButton = "ButtonPush";

		[HideInInspector]
		//The animator of the object which enters the trigger i.e Player
		public Animator animator;
		[HideInInspector]
		//Player's transform
		public Transform player;
		//flag to check if we can push button or not
		//this will make sure w3e cant push the buttons again and again		
		bool canPushBtn;
		
		// Use this for initialization
		void Start () {

			//if no door or ik target assigned
			if(!doorTarget)
				//you deserve a yellow warning
				Debug.LogWarning("No Door Target Assigned at "+ name + ". Please ensure that you assign one for this " + name + " to work!");


			if(!ikTarget)
				//you deserve a yellow warning
				Debug.LogWarning("Please assign an IKTarget for alignment of player with this push button for realistic interaction.");
		}

		//checking for input in Update()
		void Update(){
			//if there's an input
			if(Input.GetButtonDown(inputButton)){
				//but if we have player and the flag canPushBtn is true
				if(player && canPushBtn)
				{
					//match pos
					player.position = ikTarget.position;
					player.rotation = ikTarget.rotation;
					//play animator
					animator.CrossFade("Button Push", 0.2f);
					//invoke event
					Invoke("ButtonPushed", eventTime);
					//disabling the check flag
					canPushBtn = false;
				}
			}
		}

		//Button Pushed event 
		void ButtonPushed(){

			//finding the door target 
			if(doorTarget)
				//and firing it's event
				doorTarget.openDoor();
		}

		//taking all what we can as soon as player enters the Trigger
		void OnTriggerEnter(Collider c){
			//if player enters
			if(c.tag == "Player"){
				//take its transform
				player = c.transform;
				//take its animator
				animator = c.GetComponent<CharacterMotor>().animator;
				//ADD THE IK Script
				//Please see 'PushButtonIK' script for better understanding
				animator.gameObject.AddComponent<PushButtonIK>();
				//setting the Right hand IK Target with this button's transform 
				animator.GetComponent<PushButtonIK>().rightHandIKTarget = this.transform;
				//enabling the flag so we can interact
				canPushBtn = true;
			} 
		}

		//reset everything
		void OnTriggerExit(Collider c){
			//as soon as 'player' exits this trigger
			if(c.tag == "Player"){
				Destroy(animator.gameObject.GetComponent<PushButtonIK>());
				animator = null;
				player = null;

				//disabling the flag
				canPushBtn = false;
			}

		}
		
	}
}