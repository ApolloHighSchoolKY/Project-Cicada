using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TPCWC{

public class CharacterMotor : MonoBehaviour {
		
		#region Inspector Variables

		[Header("-- Player Properties --")]
		[Tooltip("How fast you want your character to move!")]
		public float moveSpeed = 2;
		[Tooltip("How fast you want your character to run!")]
		public float runSpeed = 4;
		[Tooltip("How fast you want your character to rotate with cam direction!")]
		public float rotateSpeed = 5;
		[Tooltip("Your custom attack duration. Player Movement will disabled for this amt of time while attacking!")]
		public float attackTime = 1.5f;

		#endregion

		#region Hidden Variables

		[HideInInspector]
		//Model that you have Assigned in the Creator Window!
		public GameObject modelMesh;
		[HideInInspector]
		//Vertical Input
		public float vertical;
		[HideInInspector]
		//Horizontal Input
		public float horizontal;
		[HideInInspector]
		//Delta displacement in the movement 
		public float deltaMovement;
		[HideInInspector]
		//All possible inputs from the Xbox Controller
		public bool rb, rt, lb, lt;
		[HideInInspector]
		//Movement Direction based on Camera Rotation
		public Vector3 movementDirection;
		[HideInInspector]
		//Allow Run
		public bool run;
		[HideInInspector]
		//Is player attacking?
		public bool inAttack;
		[HideInInspector]
		//Is player moving 
		public bool movement;
		[HideInInspector]
		//Model Animator
		public Animator animator;
		[HideInInspector]
		//Associated Rigidbody
		public Rigidbody rigidBody;

		float _attackDelay;

		#endregion

		//Initialize the main Character motor from the Input Manager
		public void InitializeCharacterMotor(){

			//Initialize Rigidbody parameters on Start
			rigidBody = GetComponent<Rigidbody> ();
			rigidBody.angularDrag = 999;
			rigidBody.drag = 4;
			rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | 
									RigidbodyConstraints.FreezeRotationZ;

			//Setting Player's Layer
			gameObject.layer = 8;

			//Throw debug if no model found
			if(modelMesh == null)
				Debug.Log("No Model Found");
			else
				//Retrieving the Animator
				animator = modelMesh.GetComponent<Animator>();

			//Disable Root motion
			//We will be using rigidbody for movement	
			animator.applyRootMotion = false;

		}
		
		//Doing all the Physics Calculations in Fixed Update!
		public void FixedUpdate(){
			
			//Forcing nav mesh to only work if the Player Input is disabled
			// -- PRO VERSION -- //
			//GetComponent<NavMeshAgent>().isStopped = !GetComponent<CompanionInput>().enabled;

			//Checking if the player is attacking or not
			Attack();

			//If player is attacking
			if(inAttack)
			{	
				//increment _attackDelay
				_attackDelay += Time.deltaTime;

				//if _attackDelay is greater then our attack anim duration
				if(_attackDelay > attackTime){
					//reset attack and set animation back to true
					inAttack = false;
					_attackDelay = 0;
					movement = true;
				}
				else
					//else exit the FixedUpdate() here!
					return;
			}

			//if we do have an animator
			if(animator)
			//get and set the "Move" Bool into our local movement bool  
			movement = animator.GetBool("Move");

			//if there's no movement
			if(!movement)
				//exit the FixedUpdate() here!
				return;
			
			//reset Rigidbody in case if it's tweaked
			rigidBody.drag = 4;
		
			//Make a float for target speed and get the movespeed set in the inspector!			
			float targetSpeed = moveSpeed;

			//ONLY IF player is running
			if(run)
			//we modify the target speed
			targetSpeed = runSpeed;

			//feed this into rigidbody velocity
			rigidBody.velocity = movementDirection * (targetSpeed*deltaMovement);

			//now it's time to set the direction of player
			Vector3 PlayerTargetDirection =  movementDirection;
			//set the y direction to '0' to make sure
			//player don't rotate at Y axis lol :P
			PlayerTargetDirection.y = 0;

			//if we don't have any target Direction
			if(PlayerTargetDirection == Vector3.zero)
				//we set it to player's current forward vector!
				PlayerTargetDirection = transform.forward;

			//now it's time to set the rotation of player
			Quaternion targetRot = Quaternion.LookRotation(PlayerTargetDirection);
			Quaternion PlayerTargetRotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotateSpeed * deltaMovement);
			transform.rotation = PlayerTargetRotation;

			//if there's any movement...
			if(movement)
				//we apply move animations
				{
					animator.SetBool("run", run);
					animator.SetFloat("vertical", deltaMovement, 0.3f, Time.deltaTime);
				}

		}

		//The main attack method
		//I highly recommend that you should tweak it if you have 
		//more then 1 animation
		public void Attack(){

			//if we have a weapon
			// -- PRO VERSION -- //
			// if(!GetComponent<WeaponStandalone>().weapon)
			// 	return;

			//if we are not moving
			if(!movement)
				return;

			//if there's an input(here it's lb)
			if(!lb)
				return;

			//we call attack animation!
			if(lb)
				animator.SetTrigger("attack");
			
			//disable movement if it's not already
			movement = false;

			//enable inAttack if it's not already
			inAttack = true;

			//block all movement by forcing velocity to 0
			rigidBody.velocity = Vector3.zero;
		}



	}
}