using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPCWC
{
	public class CameraController : MonoBehaviour 
	{

		#region Inspector Variables

		[Header("-- Camera Controller Properties --")]
		[Tooltip("How fast camera follows player")]
		public float followSpeed = 9;
		[Tooltip("How fast camera moves with mouse")]
		public float mouseSpeed = 2;
		[Tooltip("How fast camera moves with controller")]
		public float controllerSpeed = 7;
		[Tooltip("Minimum Rotation along X")]
		public float minRotation = -35f;
		[Tooltip("Maximum Rotation along X")]
		public float maxRotation = 35f;

		#endregion

		#region Hidden Variables

		//smoothly rotating camera around player
		float turnSmoothing = 0.1f;
		//smoothness along X
		float smoothX;
		//smoothness along Y
		float smoothY;
		//smoothness velocity along X
		float smoothXVelocity;
		//smoothness velocity along Y
		float smoothYVelocity;

		[HideInInspector]
		//Assigned automatically on start and on switching player
		public Transform PlayerTarget;
		[HideInInspector]
		//Child transform which is parent of main camera
		public Transform pivot;
		[HideInInspector]
		//the camera transform
		public Transform camTrans;
		[HideInInspector]
		//The look rotation of camera to player
		public float lookRotation;
		[HideInInspector]
		//The tilt rotation of camera to player
		public float tiltRotation;

		//Static instance so that we don't need any reference ;)
		public static CameraController instance;

		#endregion

		void Awake(){

			//Setting our static instance
			instance = this;

		}

		//initializing the camera controller on start
		public void InitializeCameraController(Transform _t){
			
			//setting the player target from retrieved _t
			PlayerTarget = _t;

			//setting the camera Transform from main camera wherever it is
			camTrans = Camera.main.transform;

			//now initializng pivot as the parent of our camTrans
			pivot = camTrans.parent;

		}

		//performing all calculations in the FixedUpdate()
		public void FixedUpdate(){

			//getting axis from Mouse
			float horizontal = Input.GetAxis("Mouse X");
			float vertical = Input.GetAxis("Mouse Y");

			//getting joystick axis
			float cam_horizontal = Input.GetAxis("JoystickAxis X");
			float cam_vertical = Input.GetAxis("JoystickAxis Y");

			//will be manipulating mouse speed
			//hence cache it in another var camTargetSpeed  
			float camTargetSpeed = mouseSpeed;

			//ONLY IF we are using the controller 
			if(cam_horizontal != 0 || cam_vertical !=0)
			{	
				//override the axis
				horizontal = cam_horizontal;
				vertical = cam_vertical;
				//override the camTargetSpeed
				camTargetSpeed = controllerSpeed;
			}

			//following player
			FollowPlayer();

			//rotating AROUND player
			RotateCamera(Time.deltaTime, vertical, horizontal, camTargetSpeed);
		}

		//rotating AROUND player
		void RotateCamera(float d, float vert, float horz, float camTargetSpeed){

			//if we have any smoothing
			if(turnSmoothing > 0){

				//rotate smoothly
				smoothX = Mathf.SmoothDamp(smoothX, horz, ref smoothXVelocity, turnSmoothing);
				smoothY = Mathf.SmoothDamp(smoothY, vert, ref smoothYVelocity, turnSmoothing);

			}
			else
			{
				//else just apply raw rotation
				smoothX = horz;
				smoothY = vert;

			}

			//now changing the tilt rotation
			tiltRotation -= smoothY * camTargetSpeed;
			//clamping it with our minRotation and maxRotation
			tiltRotation = Mathf.Clamp(tiltRotation, minRotation, maxRotation);
			//setting our pivot's LOCAL rotation NOT THE WORLDSPACE 
			pivot.localRotation = Quaternion.Euler(tiltRotation,0,0);
			
			//incrementing the look rotation with smoothness and camTargetSpeed
			lookRotation += smoothX * camTargetSpeed;

			//Finally applying it to our camera controller rotation
			transform.rotation = Quaternion.Euler(0, lookRotation, 0);

		}

		//following player
		void FollowPlayer(){

			//speed proportional to the follow speed
			float speed = Time.deltaTime * followSpeed;
			//lerping to the correct player position
			Vector3 PlayerPosition = Vector3.Lerp(transform.position, PlayerTarget.position, speed);
			
			//Finally applying it to our camera controller position
			transform.position = PlayerPosition;

		}

	}
}