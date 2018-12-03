using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TPCWC{
	[CustomEditor(typeof(GameController))]
	public class GameControllerEditor : Editor {

		bool showHelp;

		public override void OnInspectorGUI(){

			EditorGUILayout.BeginHorizontal("box");
        	
        	GUILayout.Label("Game Controller Script", EditorStyles.helpBox);

        	GUIStyle bStyle = new GUIStyle("box");
        	bStyle.normal.textColor = Color.yellow;
 
        	if(GUILayout.Button("[?]", bStyle)){
        		showHelp = !showHelp;
        	}

        	EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginVertical("box");

			if(showHelp){
					EditorGUILayout.HelpBox("This is the Game Controller Script which will be managing the toggle between player-companion and follow-unfollow!\n\nP1 :\tAssign here the first Player.\n\nP2 :\tAssign here the second Player.\n\nInactive P : Auto Assigned at RUNTIME with the player which is behaving as the Companion driven by AI Input.\n\nActive P : Auto Assigned at RUNTIME with the player which is behaving as the Player driven by User Input.\n\nRestart Delay : Define the delay you want in restarting scene when both player-companion dies!(You must Replace this logic if you want something else to happen when both dies like an end screen!)\n\nFollow Button : Type the Button name that you have defined in Input for toggling the Companion Follow!\n\nSwitch Player Button :  Type the Button name that you have defined in Input for toggling between Player and Companion!", MessageType.Info);
    		}

			base.DrawDefaultInspector();

			EditorGUILayout.EndVertical();

		}
	}
}