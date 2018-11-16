using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPCWC{
	public class PushButtonIK : MonoBehaviour {

		//the animator of this transform 
		Animator animator;

		[Tooltip("Where we will send our right hand? ;)")]
		public Transform rightHandIKTarget;

		[Tooltip("Right Hand weight, it is manipulated in the animation curve in the ButtonPush animation")]
		[Range(0f,1f)]
		public float rhWeight;

		// Use this for initialization
		void Start(){
			//get animator references
			animator = GetComponent<Animator>();
		}

		//Using this Unity's method to override the Current Right hand IK 
		void OnAnimatorIK(){
			
			//if we have a target
			if(rightHandIKTarget){

				//get the right hand weight from the animator
				rhWeight = animator.GetFloat("RightHand");
				
				//set position
				animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandIKTarget.position);
				//set position weight
				animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rhWeight);

				//set rotation
				animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandIKTarget.rotation);
				//set rotation weight
				animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rhWeight);
			}

		}
	}
}