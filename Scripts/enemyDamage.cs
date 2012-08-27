using UnityEngine;
using System.Collections;

public class enemyDamage : MonoBehaviour {
	public int Damage = 10;
	public bool dealDamage;
	public float coolDown;
	public float initialCoolDown = 3f;
	
	public playerHealth pHealth;
	
	void Start () {
		dealDamage = false;
		coolDown = 3f;
	}
	void Update () {
		
		if (coolDown > 0)
			coolDown -= Time.deltaTime;
		if (coolDown < 0)
			coolDown = 0f;
		if (coolDown == 0f){
			dealDamage = true;
			coolDown = initialCoolDown;
		}
	}
	
	void OnTriggerEnter (Collider other) {
		if ((other.gameObject.tag.Contains("Player")) && (dealDamage == true)){
			pHealth.Health -= Damage;
			dealDamage = false;
		}
	}
}
