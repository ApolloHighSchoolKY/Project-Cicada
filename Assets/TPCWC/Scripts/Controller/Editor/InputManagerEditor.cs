using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace TPCWC{
	[CustomEditor(typeof(InputManager))]
	public class InputManagerEditor : Editor {

		bool showHelp;

		public override void OnInspectorGUI()
	    {

    		EditorGUILayout.BeginHorizontal("box");
        	
        	GUILayout.Label("Input Manager Script", EditorStyles.helpBox);

        	GUIStyle bStyle = new GUIStyle("box");
        	bStyle.normal.textColor = Color.yellow;
 
        	if(GUILayout.Button("[?]", bStyle)){
        		showHelp = !showHelp;
        		
        	}

        	EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginVertical("box");

			if(showHelp){
					EditorGUILayout.HelpBox("This is the Standalone Input Manager Script!\nThis is the script responsible (you might have already guessed) for all the inputs.", MessageType.Info);
    		}

			base.DrawDefaultInspector();

			EditorGUILayout.EndVertical();

	    }
	}
}