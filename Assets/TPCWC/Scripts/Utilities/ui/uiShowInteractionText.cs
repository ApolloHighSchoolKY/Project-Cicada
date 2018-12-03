using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TPCWC{
	public class uiShowInteractionText : MonoBehaviour {

		public string displayText;
		
		// Use this for initialization
		void Start () {

		}

		void OnTriggerEnter(Collider c){
			if(c.tag == "Player"){
				
				//if the swtich was successful, display text
				Text InteractionText = GameObject.Find("InteractionText").GetComponent<Text>();
				if(InteractionText){
					InteractionText.text = displayText;
					InteractionText.GetComponent<Animator>().Play("InteractionText");
				}
			
			}
		}
	
		
	}
}