using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TPCWC{

	[CustomEditor(typeof(CameraController))]
	public class CameraControllerEditor : Editor {

		bool showHelp;

        public override void OnInspectorGUI()
        {
        	EditorGUILayout.BeginHorizontal("box");
        	
        	GUILayout.Label("Camera Controller Script", EditorStyles.helpBox);

        	GUIStyle bStyle = new GUIStyle("box");
        	bStyle.normal.textColor = Color.yellow;
 
        	if(GUILayout.Button("[?]", bStyle)){
        		showHelp = !showHelp;
        		
        	}

        	EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginVertical("box");

			if(showHelp){
    			EditorGUILayout.HelpBox("Follow Speed :\tHow fast the Camera Follows the Player\n\nMouse Speed :\tHow fast Camera Rotates with mouse\n\nController Speed :\tCamera rotation speed with X-Box Controller!\n\nMin Rotation :\tMinimum Allowed Rotation\n\nMax Rotation :\tMaximum Allowed Rotation\n\nPlayerTarget :\tWil be autoassigned to current player", MessageType.Info);
    		}

			base.DrawDefaultInspector();

			EditorGUILayout.EndVertical();
        }
		
	}

}