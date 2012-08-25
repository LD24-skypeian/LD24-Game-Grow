using UnityEngine;
using System.Collections;

public class playerEnergy : MonoBehaviour {
	public int energy = 0;			// an adjustable amount of energy that is affected by Constant gameplay.
	public int maxEnergy = 100;		//the maximum amount of energy the player will have.
	
	private foodPills energyFood;
	
	void Awake () {
		energyFood = GameObject.Find ("food").GetComponent<foodPills>();
	}
	
	void Start () {
		energy = 100;
	}
	
	void OnCollisionEnter (Collision other) {
		if (energy != maxEnergy){
			if (other.gameObject.tag.Contains ("food")) {
				energy = energy + energyFood.energyPills;
			}
		}
	}
	
}