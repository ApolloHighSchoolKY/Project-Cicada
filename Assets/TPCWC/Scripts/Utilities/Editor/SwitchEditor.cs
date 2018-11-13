using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TPCWC{
	[CustomEditor(typeof(Switch))]
	public class SwitchEditor : Editor {


		bool showHelp;
		public  override void OnInspectorGUI(){

			EditorGUILayout.BeginHorizontal("box");
        	
        	GUILayout.Label("Switch Script", EditorStyles.helpBox);

        	GUIStyle bStyle = new GUIStyle("box");
        	bStyle.normal.textColor = Color.yellow;
 
        	if(GUILayout.Button("[?]", bStyle)){
        		showHelp = !showHelp;
        	}

        	EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginVertical("box");

			if(showHelp){

				EditorGUILayout.HelpBox("This is a pushable switch script. Use it for opening and closing of the doors.\n\nDoor Target :\tAssign the 'Door' object you want to open with this Script.\n\nClose Door On Exit : If true, as soon as the Player exits this switch trigger, door will close again!", MessageType.Info);
    		}

			base.DrawDefaultInspector();

			EditorGUILayout.EndVertical();

		}
		
	}
}