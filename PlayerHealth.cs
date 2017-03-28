using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float maxHealth = 100f;
	public float currentHealth = 0f;
	public GameObject healthBar;

	void Start (){
		currentHealth = maxHealth;
		InvokeRepeating("decreasehealth", 0.01f,0.01f);

	}
	void decreasehealth(){
		//currentHealth -= 2;
		float calc_Health = currentHealth / maxHealth; //
		SetHealBar (calc_Health);

	}

	public void SetHealBar(float myHealth){
		//myHealth es un valor entre 0-1,
		healthBar.transform.localScale = new Vector3 (myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}

}