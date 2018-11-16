using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleParameter : StateMachineBehaviour {

	public string parameterName;
	public bool enableOnEnter = true; 

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool(parameterName, enableOnEnter);
	}

	

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool(parameterName, !enableOnEnter);
	
	}


	
}
