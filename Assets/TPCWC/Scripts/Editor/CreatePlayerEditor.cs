using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

namespace TPCWC{
	
	public class CreatePlayerEditor : EditorWindow {

	
		AnimatorController animator;
		GameObject model;
		string playerName = "TPCWC Player";

		[MenuItem("TPCWC/Create Character/Player #&p", false, 1)]
		public static void OpenPlayerCreatorWindow(){

			GetWindow<CreatePlayerEditor>("Player");
			GetWindow<CreatePlayerEditor>("Player").minSize = new Vector2(400,300);

		}


		void OnGUI(){

			GUILayout.Label("Player Creator Window!", EditorStyles.centeredGreyMiniLabel);

			GUILayout.Space(15);
			GUILayout.BeginVertical("box");
			
			playerName = EditorGUILayout.TextField("Player Name",playerName, EditorStyles.textField);
			animator = (AnimatorController)EditorGUILayout.ObjectField("Animator", animator, typeof(AnimatorController), true) ;
			model = (GameObject) EditorGUILayout.ObjectField("Player Model", model, typeof(GameObject),true);

			if(model && !model.GetComponent<Animator>())
				EditorGUILayout.LabelField("Please Select a valid GameObject as 'Player Model' with Animator Attached!", EditorStyles.helpBox);
			else
			{
				if(playerName != "" && model != null && animator != null){

					if(GUILayout.Button("Create Player"))
					{
						AddComponentsToPlayer();
					}

				}else
				{
					GUILayout.Label("Assign all fields to proceed.", EditorStyles.centeredGreyMiniLabel);
				}
			}
			

			CreateOtherButtons();

			GUILayout.EndVertical();

		}

		void AddComponentsToPlayer(){

			//Create Empty Instance
			GameObject playerRes;
			GameObject childModel;

			//Instantiate Proper Objects
			playerRes = Instantiate(Resources.Load("Player/PlayerResource")) as GameObject;
			childModel = Instantiate(model) as GameObject;

			//Apply animator Controller 
			childModel.GetComponent<Animator>().runtimeAnimatorController = animator;
			childModel.GetComponent<Animator>().applyRootMotion = false;	
			
			//Set it as child
			childModel.transform.SetParent(playerRes.transform);
			childModel.transform.localPosition = Vector3.zero;
			childModel.transform.localRotation = Quaternion.identity;

			//Set reference in Script
			playerRes.GetComponent<CharacterMotor>().modelMesh =  childModel;

			//change Name
			playerRes.name = playerName;


			//Load other needed components
			GameObject gameController;
			GameObject cameraController;
			GameObject ui;

			gameController = Instantiate(Resources.Load("Objects/GameController")) as GameObject;
			gameController.GetComponent<GameController>().p1 = playerRes.GetComponent<InputManager>();
			gameController.name = "Game Controller";

			if(FindObjectOfType<Camera>())
				DestroyImmediate(FindObjectOfType<Camera>().gameObject);

			cameraController = Instantiate(Resources.Load("Objects/CameraController")) as GameObject;
			cameraController.name = "Camera Controller";

			ui = Instantiate(Resources.Load("Objects/UI")) as GameObject;
			ui.name = "UI";

			GetWindow<CreatePlayerEditor>("Player").Close();

			//Debug appear if everything is succesful
			Debug.Log(playerName + " Created!");

		}

		void CreateOtherButtons(){

			GUILayout.BeginHorizontal(EditorStyles.helpBox);

			if(GUILayout.Button("Watch Tutorial")){

				Application.OpenURL("www.youtube.com");
			}

			if(GUILayout.Button("Visit Forum")){

				Application.OpenURL("www.forum.unity3d.com");
			}

			GUILayout.EndHorizontal();
		}

	}
}