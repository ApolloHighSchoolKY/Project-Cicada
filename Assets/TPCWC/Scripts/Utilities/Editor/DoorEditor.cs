using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TPCWC{
	[CustomEditor(typeof(Door))]
	public class DoorEditor : Editor {


		bool showHelp;
		public override void OnInspectorGUI(){

			EditorGUILayout.BeginHorizontal("box");
        	
        	GUILayout.Label("Door Script", EditorStyles.helpBox);

        	GUIStyle bStyle = new GUIStyle("box");
        	bStyle.normal.textColor = Color.yellow;
 
        	if(GUILayout.Button("[?]", bStyle)){
        		showHelp = !showHelp;
        	}

        	EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginVertical("box");

			if(showHelp){

				EditorGUILayout.HelpBox("Attach this to any object which you want to Animate via Push Button or a Switch.\n\nDoor Open Animation :\tName of the animation which opens the door\n\nDoor Close Animation :\tName of the animation which Closes the door\n\nNeed Key :\t\tIf true, door opens automatically.", MessageType.Info);
    		}

			base.DrawDefaultInspector();

			EditorGUILayout.EndVertical();

		}

		
	}
}