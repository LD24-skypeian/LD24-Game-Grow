using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour
{
	public int health = 0; // an adjustable amount of health that is affected by gameplay.
	public int maxHealth = 100; //the maximum amount of health the player will have.

	private foodPills healthFood;
	
	public int Health{
		get
		{
			return health;
		}
		set
		{
			health = value;
		}
	}
	
	private void Awake()
	{
		healthFood = GameObject.FindWithTag("food").GetComponent<foodPills>();
	}

	private void Start()
	{
		Health = 100;
	}

	private void Update()
	{
		if (Health > maxHealth)
			Health = maxHealth;
		if (Health < 0){
			Destroy(gameObject);
//			Application.LoadLevel("GameOver");
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Contains("food"))
		{
			if (health != maxHealth)
			{
				Debug.Log("FoodCount++");
				Health += healthFood.healthPills;
			}
			growPoints.FoodCount++;
		}
	}
}
