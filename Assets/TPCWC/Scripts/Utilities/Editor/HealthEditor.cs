using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace TPCWC{

	[CustomEditor(typeof(Health))]
	public class HealthEditor : Editor {

		bool showHelp;

	    public override void OnInspectorGUI(){

	    	EditorGUILayout.BeginHorizontal("box");
        	
        	GUILayout.Label("Health Script", EditorStyles.helpBox);

        	GUIStyle bStyle = new GUIStyle("box");
        	bStyle.normal.textColor = Color.yellow;
 
        	if(GUILayout.Button("[?]", bStyle)){
        		showHelp = !showHelp;
        	}

        	EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginVertical("box");

			if(showHelp){
				EditorGUILayout.HelpBox("Standalone Health Script.\nAttach this to any Companion or Player or Enemy you want to recieve damage on.\n\nMax Health :\tThe maximum amount of health you want this object to have.\n\nCurrent Health :\tThe current health you will see at RUNTIME of this object.\n\nAnimator :\tIt will be auto assigned to this object's animator.", MessageType.Info);
    		}

			base.DrawDefaultInspector();

			EditorGUILayout.EndVertical();
	        
		}
    }
}