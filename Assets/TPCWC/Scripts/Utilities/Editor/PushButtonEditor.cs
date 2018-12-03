using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TPCWC{
	[CustomEditor(typeof(PushButton))]
	public class PushButtonEditor : Editor {

		bool showHelp;
	    public override void OnInspectorGUI()
        {
           EditorGUILayout.BeginHorizontal("box");
        	
        	GUILayout.Label("Push Button Script", EditorStyles.helpBox);

        	GUIStyle bStyle = new GUIStyle("box");
        	bStyle.normal.textColor = Color.yellow;
 
        	if(GUILayout.Button("[?]", bStyle)){
        		showHelp = !showHelp;
        	}

        	EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginVertical("box");

			if(showHelp){
					EditorGUILayout.HelpBox("Attach this script to an Object which will act as a pushable button which will then trigger the Door Open.\n\nIK Target :\tThe position and rotation which you want player to align while interacting with this Push Button.\n\nEvent Time :\tTime in seconds when you want the Open Door Event to occur. Coordinate this time with your animation, for default animation it is at 1.1s.\n\nDoor Target :\tDoor you want to open with this Push Button.\n\nInput Button :\tButton name that we have defined in Input that will Trigger the Push Button Event!(Right now it's set to 'P') \n\nNOTE :\nThis Script Attaches the 'PushButtonIK' script at RUNTIME to the Player's Animator Object as soon as it starts interaction.\n'PushButtonIK' script is responsible for the IK Matching of the Right Hand of this Player. ", MessageType.Info);
    		}

			base.DrawDefaultInspector();

			EditorGUILayout.EndVertical();


        }
	}
}