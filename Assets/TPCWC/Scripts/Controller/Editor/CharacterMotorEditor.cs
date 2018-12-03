using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace TPCWC{
	
	[CustomEditor(typeof(CharacterMotor))]
	public class CharacterMotorEditor : Editor {

	bool showHelp;

    public override void OnInspectorGUI()
        {
            EditorGUILayout.BeginHorizontal("box");
        	
        	GUILayout.Label("Character Motor Script", EditorStyles.helpBox);

        	GUIStyle bStyle = new GUIStyle("box");
        	bStyle.normal.textColor = Color.yellow;
 
        	if(GUILayout.Button("[?]", bStyle)){
        		showHelp = !showHelp;
        	}

        	EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginVertical("box");

			if(showHelp){
					EditorGUILayout.HelpBox("This is the Main Character Motor Script!\nYou can easily manipulate the following variables of this perticular controller :\n\nModel Mesh :\tThe Humanoid Model of this character which holds the animator component.\n\nMove Speed :\tDefine how fast you want player to move.\n\nRun Speed :\tDefine how fast you want player to run.\n\nRotate Speed :\tDefine how fast you want player to rotate.\n\nAttack Time :\tHow long is your Attack animation.", MessageType.Info);
    		}

			base.DrawDefaultInspector();

			EditorGUILayout.EndVertical();
        }
	}
}