using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPCWC{

	public class InputManager : MonoBehaviour {

		#region Inspector Variables

		[Header("All Input Names")]
		//Not all inputs are used but they are defined in code
		//for YOU to extend the functionality of TPCWC
		public string VerticalAxis = "Vertical";
		public string HorizontalAxis = "Horizontal";
		public string B_xbox = "B";
		public string A_xbox = "A";
		public string Y_xbox = "Y";
		public string X_xbox = "X";
		public string RTButton = "RT";
		public string RTAxis = "RT";
		public string LTButton = "LT";
		public string LTAxis = "LT";
		public string RBButton = "RB";
		public string LBButton = "LB";

		#endregion

		#region Hidden Variables

		[HideInInspector]	
		public float vertical;
		[HideInInspector]	
		public float horizontal;
		//XBOX buttons and axis
		bool xbox_B;
		bool xbox_A;
		bool xbox_X;
		bool xbox_Y;
		bool xbox_RB;
		float xbox_RT;
		bool xbox_rti;
		bool xbox_lbi;
		float xbox_LT;
		bool lt_input; 

		[HideInInspector]	
		//char motor reference
		public CharacterMotor charMotor;
		//cam controller reference
		CameraController cam; 

		#endregion

		// Use this for initialization
		void Start () {

			//initialize the Character Motor
			charMotor = GetComponent<CharacterMotor> ();
			charMotor.InitializeCharacterMotor ();

			//initialize the Camera Controller
			cam = CameraController.instance;
			cam.InitializeCameraController(this.transform);
		}
		
		void FixedUpdate() {

			//Setting input
			AllInputs();
			//updating Character Motor with the Inputs
			UpdateCharacterMotor();

		}

		//setting all inputs
		void AllInputs(){
			//getting the vertical and horizontal
			vertical = Input.GetAxis(VerticalAxis);
			horizontal = Input.GetAxis(HorizontalAxis);

			//mapping x-box 360 controls
			xbox_B = Input.GetButton(B_xbox);
			xbox_A = Input.GetButton(A_xbox);
			xbox_Y = Input.GetButtonUp(Y_xbox);
			xbox_X = Input.GetButton(X_xbox);
			xbox_rti = Input.GetButton(RTButton);
			xbox_RB = Input.GetButton(RBButton);
			xbox_lbi = Input.GetButton(LBButton);

			xbox_RT = Input.GetAxis(RTAxis);

			if(xbox_RT != 0)
				xbox_rti = true;

			lt_input = Input.GetButton(LTButton);
			xbox_LT = Input.GetAxis(LTAxis);
			if(xbox_RT != 0)
				lt_input = true;

		}

		//Based on the inputs taken above
		//redefining the Character Motor
		void UpdateCharacterMotor(){

			//setting character motor's horizontal to horz input
			charMotor.horizontal = horizontal;
			//setting character motor's vertical to vert input
			charMotor.vertical = vertical;

			//caching the vert direction with forward direction 
			Vector3 vert = vertical * cam.transform.forward;
			//caching the horz direction with right direction 
			Vector3 horz = horizontal * cam.transform.right;

			//applying both as the movement Direction of our player
			charMotor.movementDirection = (vert+horz).normalized;  

			//clamping the delta movement with the Absolute value of horz and vert input 
			charMotor.deltaMovement = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));

			//if xbox_B is pressed
			if(xbox_B)
				//RUN!
				charMotor.run = (charMotor.deltaMovement > 0);
			else
				//DON'T RUN!
				charMotor.run = false;

			//setting other flags of char motor
			charMotor.rt = xbox_rti;
			charMotor.rb = xbox_RB;
			charMotor.lt = lt_input;
			charMotor.lb = xbox_lbi;

		}

	}

}