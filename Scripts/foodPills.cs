using UnityEngine;
using System.Collections;

public class foodPills : MonoBehaviour {
	public int energyPills = 20;
	public int healthPills = 20;
	
	private playerHealth pHealth;
	
	void Awake () {
		pHealth = GameObject.Find("Player").GetComponent<playerHealth>();
	}
	
	void Update () {
		 playerHealthCheck();
	}
	
	void playerHealthCheck () {
		if (pHealth.health == pHealth.maxHealth){
			energyPills = energyPills + healthPills;
		} else {
			energyPills = energyPills;
		}
	}
}
