using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TPCWC{
	public class GameController : MonoBehaviour {


		#region Inspector Variables
		
		[Header("-- Game Controller Properties --")]
		[Tooltip("Both Player and Companion Input Managers")]
		public InputManager p1,p2;
		[Tooltip("Setting current Companion as inactive Player")]
		public InputManager inactiveP;
		[Tooltip("Setting current Player as active Player")]
		public InputManager activeP;
		[Tooltip("When both dies, game will restart in 'restartDelay' seconds ")]
		public float restartDelay = 2f;

		[Header("Input Buttons")]
		[Tooltip("Define 'FollowButton' in Input Settings")]
		public string FollowButton = "Follow";
		[Tooltip("Define 'SwitchPlayerButton' in Input Settings")]
		public string SwitchPlayerButton = "Fire2";

		#endregion

		#region Hidden Variables
		
		[HideInInspector]
		public int remainingPlayers = 2;

		#endregion
		
		// Use this for initialization
		void Start () {
			
			//Initialize
			InitializePlayers();
		}
		
		//Initialize
		void InitializePlayers(){

			//setting activeP and inactiveP
			if(p1.enabled){
			
				activeP = p1;
				inactiveP = p2;
			
			}else{
			
				activeP = p2;
				inactiveP = p1;

			}

		}

		// Update is called once per frame
		void Update () {

			//Getting Input
			if(Input.GetButtonDown(SwitchPlayerButton))
				switchPlayer();

			//Getting Input
			// -- PREMIUM VERSION -- //
			// if(Input.GetButtonUp(FollowButton) && (p1 && p2))
			// 	inactiveP.GetComponent<CompanionInput>().ToggleFollow();

		} 

		//Main method for switching players
		public void switchPlayer()
		{

			//if both players are alive
			//then only we can switch
			// -- PRO VERSION -- //
			// if(p1 && p2){

			// 	//RESET BOTH PLAYER SETTINGS IN THIS FRAME
			// 	p1.GetComponent<CompanionInput>().canFollow = false;
			// 	p1.GetComponent<CompanionInput>().chase = false;
			// 	p1.GetComponent<CompanionInput>().attack = false;
			// 	p1.GetComponent<CharacterMotor>().run = false;
			// 	p1.GetComponentInChildren<Animator>().SetBool("run", false);
			// 	p1.GetComponent<CharacterMotor>().vertical = 0;
			// 	p1.GetComponent<CharacterMotor>().deltaMovement = 0;
			// 	p1.GetComponentInChildren<Animator>().SetFloat("vertical", 0);

			// 	p2.GetComponent<CompanionInput>().canFollow = false;
			// 	p2.GetComponent<CompanionInput>().chase = false;
			// 	p2.GetComponent<CompanionInput>().attack = false;
			// 	p2.GetComponent<CharacterMotor>().run = false;
			// 	p2.GetComponentInChildren<Animator>().SetBool("run", false);
			// 	p2.GetComponent<CharacterMotor>().vertical = 0;
			// 	p2.GetComponent<CharacterMotor>().deltaMovement = 0;
			// 	p2.GetComponentInChildren<Animator>().SetFloat("vertical", 0);
				
			// 	//now, if p1 is enabled i.e p1 is our current player
			// 	if(p1.enabled){

			// 		//disable it and set it as our companion
			// 		p1.enabled = false;
			// 		p1.vertical = 0;
			// 		p1.GetComponent<CharacterMotor>().run = false;
			// 		p1.charMotor.animator.SetFloat("vertical", p1.vertical);
			// 		p1.GetComponent<CompanionInput>().enabled = true;
			// 		p1.GetComponent<CompanionInput>().companionSensor.enabled = true;
			// 		p1.GetComponent<Rigidbody>().isKinematic = true;

			// 		//enable p2 and set it as main player
			// 		p2.enabled = true;
			// 		p2.GetComponent<CompanionInput>().companionSensor.enabled = false;
			// 		p2.GetComponent<Rigidbody>().isKinematic = false;
			// 		p2.GetComponent<CompanionInput>().enabled = false;
			// 		FindObjectOfType<CameraController>().PlayerTarget = p2.transform;

			// 		//re initialize the inactiveP and activeP
			// 		inactiveP = p1;
			// 		activeP = p2;
			// 	}
			// 	//else if p2 is enabled i.e p2 is our current player 
			// 	else
			// 	{
			// 		//disable it and set it as our companion
			// 		p2.enabled = false;
			// 		p2.vertical = 0;
			// 		p2.charMotor.animator.SetFloat("vertical", p2.vertical);
			// 		p2.GetComponent<CharacterMotor>().run = false;
			// 		p2.GetComponent<Rigidbody>().isKinematic = true;
			// 		p2.GetComponent<CompanionInput>().enabled = true;
			// 		p2.GetComponent<CompanionInput>().companionSensor.enabled = true;
			// 		p2.GetComponent<Rigidbody>().isKinematic = true;

			// 		//enable p1 and set it as main player
			// 		p1.enabled = true;
			// 		p1.GetComponent<CompanionInput>().companionSensor.enabled = false;
			// 		p1.GetComponent<Rigidbody>().isKinematic = false;
			// 		p1.GetComponent<CompanionInput>().enabled = false;
			// 		FindObjectOfType<CameraController>().PlayerTarget = p1.transform;

			// 		//re initialize the inactiveP and activeP
			// 		inactiveP = p2;
			// 		activeP = p1;
					
			// 	}

			// 	//if the swtich was successful, display text
			// 	Text InteractionText = GameObject.Find("InteractionText").GetComponent<Text>();
			// 	if(InteractionText){
			// 		InteractionText.text = "Player Switched";
			// 		InteractionText.GetComponent<Animator>().Play("InteractionText");
			// 	}

			// }

		}

		//Now if one player dies, we set the remaining one to be the main player
		public void SetNextPlayerOnDeath(){
			//if we have p1 i.e p1 is the one remaining and now setting
			//him as the player
			// -- PRO VERSION -- //
			// if(p1 )
			// {
			// 	p1.enabled = true;
			// 	p1.GetComponent<CompanionInput>().companionSensor.enabled = false;
			// 	p1.GetComponent<Rigidbody>().isKinematic = false;
			// 	p1.GetComponent<CompanionInput>().enabled = false;
			// 	FindObjectOfType<CameraController>().PlayerTarget = p1.transform;
			// }

			// //if we have p2 i.e p2 is the one remaining and now setting
			// //him as the player
			// if(p2 )
			// {
			// 	p2.enabled = true;
			// 	p2.GetComponent<CompanionInput>().companionSensor.enabled = false;
			// 	p2.GetComponent<Rigidbody>().isKinematic = false;
			// 	p2.GetComponent<CompanionInput>().enabled = false;
			// 	FindObjectOfType<CameraController>().PlayerTarget = p2.transform;
			// }

		}

		//If noone remains, we will restart scene
		//I recommend it to overwrite with your own logic
		public void RestartScene(){

			if(remainingPlayers == 0){
				Debug.Log("Player and Companion Died! Restarting Level in " + restartDelay + " seconds.");
				Invoke("restart", restartDelay);
			}
		}

		void restart(){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		}

	}

}