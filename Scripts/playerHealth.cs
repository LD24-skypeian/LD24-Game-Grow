using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {
	public int health = 0;			// an adjustable amount of health that is affected by gameplay.
	public int maxHealth = 100;		//the maximum amount of health the player will have.
	
	private foodPills healthFood;
	
	void Awake () {
		healthFood = GameObject.Find("food").GetComponent<foodPills>();
	}
	
	void Start () {
		health = 100;	
	}
	
	void Update () {
		if (health > maxHealth)
			health = maxHealth;
	}
	
	void OnTriggerEnter (Collider other) {
		if (health != maxHealth){
			if (other.gameObject.tag.Contains ("food")) {
				health = health + healthFood.healthPills;
			}
		}
	}
	
}
