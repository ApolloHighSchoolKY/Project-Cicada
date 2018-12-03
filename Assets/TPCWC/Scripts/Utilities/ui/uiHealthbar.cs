using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TPCWC{
	public class uiHealthbar : MonoBehaviour {

		public Slider healthBar;
		public Health playerHealth;
		public float lerpDuration = .5f;
		// Use this for initialization
		void Start () {
			healthBar.maxValue = playerHealth.maxHealth;
			healthBar.value = playerHealth.maxHealth;
		}

		public void ChangeHealthBarValue(){

			StartCoroutine(LerpHealthbar(lerpDuration));



		}

		 IEnumerator LerpHealthbar(float time )
		 {
		     float elapsedTime = 0;
		     while (elapsedTime < time)
		     {
		         healthBar.value = Mathf.Lerp(healthBar.value, playerHealth.currentHealth, (elapsedTime / time));
		         elapsedTime += Time.deltaTime;
		         	
	         	if(healthBar.value <1)
					Destroy(this.gameObject);
		         yield return null;
		     }
		 }
		
	}
}