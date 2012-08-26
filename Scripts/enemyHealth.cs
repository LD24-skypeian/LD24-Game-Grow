using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {
	public int health = 10;
	
	public bulletScript bDamage;
	
	void start () {
		//bDamage = GameObject.FindWithTag("bullet").GetComponent<bulletScript>();
	}

	// Update is called once per frame
	void Update () {
		if(health <= 0)
			Destroy(this.gameObject);
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag.Contains("bullet"))
			health -= bDamage.bulletDamage;
	}

}
