using UnityEngine;
using System.Collections;

public class playerEnergy : MonoBehaviour {
	public int energy = 0;			// an adjustable amount of energy that is affected by Constant gameplay.
	public int maxEnergy = 100;		//the maximum amount of energy the player will have.
	public float maxTimeEnergy = 2f;
	public float timeEnergy;
	
	private foodPills energyFood;
	
	void Awake () {
		energyFood = GameObject.Find("food").GetComponent<foodPills>();
	}
	
	void Start () {
		energy = 23;
	}
	
	void Update () {
		if (energy > maxEnergy)
			energy = maxEnergy;
		energyLoss();
		playerSpeed();
	}
	
	void OnTriggerEnter (Collider other) {
		if (energy != maxEnergy){
			if (other.gameObject.tag.Contains ("food")) {
				energy = energy + energyFood.energyPills;
			}
		}
	}
	
	void energyLoss ()
	{
		//Debug.Log("isMoving: " + TadPoleMovementController.isMoving);

		if (TadPoleMovementController.isMoving)
		{
			timeEnergy -= Time.deltaTime;
		}
		if (timeEnergy < 0f)
		{
			energy -= 1;
			timeEnergy = maxTimeEnergy;
		}		
	}
	
	void playerSpeed (){
		if (energy < 20){
			TadPoleMovementController.speed *= .75f;
		} else if (energy < 10){
			TadPoleMovementController.speed *= .50f;
		} else {
			TadPoleMovementController.speed = TadPoleMovementController.baseSpeed;
		}
			
	}
}
