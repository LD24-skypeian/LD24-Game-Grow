using UnityEngine;
using System.Collections;

public class playerEnergy : MonoBehaviour {
	public int energy = 0;			// an adjustable amount of energy that is affected by Constant gameplay.
	public int maxEnergy = 100;		//the maximum amount of energy the player will have.
	public float timeEnergy = 2f;
	
	private foodPills energyFood;
	
	void Awake () {
		energyFood = GameObject.Find("food").GetComponent<foodPills>();
	}
	
	void Start () {
		energy = 100;
	}
	
	void Update () {
		if (energy > maxEnergy)
			energy = maxEnergy;
		energyLoss();
	}
	
	void OnTriggerEnter (Collider other) {
		if (energy != maxEnergy){
			if (other.gameObject.tag.Contains ("food")) {
				energy = energy + energyFood.energyPills;
			}
		}
	}
	
	void energyLoss () {
		if (this.transform){
			timeEnergy -= Time.deltaTime;
		}
		if (timeEnergy < 0f){
			energy -= 1;
			timeEnergy = timeEnergy;
		}
		
	}
	
}
