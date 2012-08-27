using UnityEngine;
using System.Collections;

public class StorkAttack : MonoBehaviour
{

	public int Damage = 25;
	public playerHealth pHealth;

	void Awake()
	{
		if (pHealth == null)
		{
			pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("ATTACK!");
		//Debug.Log(other.tag);

		if (other.gameObject.tag.Contains("Player"))
		{
			Debug.Log("Trigger Stork ATTACK!");
			pHealth.Health -= Damage;
		}
	}
}
