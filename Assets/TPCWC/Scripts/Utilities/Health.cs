using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TPCWC{

	public class Health : MonoBehaviour {

		[Header("-- Standalone Health --")]
		[Tooltip("Define how much health this character can have")]
		public int maxHealth = 100;
		[Tooltip("Display how much remaining health this character has (RUNTIME)")]
		public int currentHealth;

		[Space(10)]
		[Tooltip("Will be auto-assigned")]
		public Animator animator;

		// Use this for initialization
		void Start () {

			//because they say use this for initialization *_*
			Initialize();
		}
		
		void Initialize(){

			//initializing current health with the max health on start
			currentHealth = maxHealth;
			//finding animator
			animator = GetComponentInChildren<Animator>();

		}

		//public method to take and apply damage
		//if this value is -ve, the health will increase.. i guess so...
		public void onDamage(int val){

			//if there's an animator and it's already in the hit state
			if(animator)
				if(animator.GetCurrentAnimatorStateInfo(2).IsName("Hit"))
					//EXIT
					return;

			//reducing the current health with the val passed in
			currentHealth -= val; 

			//if current health reaches 0
			if(currentHealth <=0){
				
				//DIEEE
				Death();
			}
			else{
				//else React
				HitReaction();
			}

			//finding the healthbar in children
			uiHealthbar healthbar = GetComponentInChildren<uiHealthbar>();
			if(healthbar){
				//if we found one, lerp the slider to current health 
				healthbar.ChangeHealthBarValue();				
			}
		}

		//the hit reaction
		public void HitReaction(){

			//if we have an animator
			if(animator)	
				//if we already not in the hit reaction clip
				if(!animator.GetCurrentAnimatorStateInfo(2).IsName("Hit"))
					//then play the hit animation!
					animator.SetTrigger("hit");

		}

		//if we die
		public void Death(){

			//if we have an animator
			if(animator)
				//play the death animation
				animator.SetTrigger("death");

		//******DESTROYING ALL COMPONENTS******//
		NavMeshAgent nav = GetComponent<NavMeshAgent>();
		Collider c = GetComponent<Collider>();
		// -- PRO VERSION -- //
		// EnemyAI enemy = GetComponent<EnemyAI>();
		// CompanionInput cInput = GetComponent<CompanionInput>();
		InputManager ih = GetComponent<InputManager>();
		CharacterMotor cm = GetComponent<CharacterMotor>();
		Rigidbody r = GetComponent<Rigidbody>();

		gameObject.tag = "Untagged";

		// -- PRO VERSION -- //
		// if(enemy)
		// 	Destroy(enemy);

		if(cm)
			Destroy(cm);

		// -- PRO VERSION -- //
		// if(cInput){
		// 	//set next player if one dies
		// 	if(!cInput.enabled)
		// 		FindObjectOfType<GameController>().SetNextPlayerOnDeath();

		// 	Destroy(ih);
		// 	Destroy(cInput);

		// 	FindObjectOfType<GameController>().remainingPlayers--;
		// }

		if(nav)	
			Destroy(nav);

		if(c)
			Destroy(c);
		
		if(r)
			Destroy(r);

		FindObjectOfType<GameController>().RestartScene();

		//finally destroy this as well!
		Destroy(this);

		}
		
	}
}