using UnityEngine;
using System.Collections;

//Have this script add up the total of growPoints.

public class growPoints : MonoBehaviour {
	private float timer = 0f;
	private float coolDown = 6.0f;
	public int growPoint = 0;		//the grow points
	
	void Update () {
		timeUntilGP ();		
	}
	
	//if the player hits something, it resets the counter, otherwise, after 6 seconds, the player gains a GP
	void timeUntilGP () {
		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		
		if (timer < 0) {
			timer = 0f;
		}
		
		if (timer == 0) {
			timer = coolDown;
			growPointCounter ();
		}
	}
	
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag.Contains("Enemy"))
			timer = coolDown;
	}
	//player gains GP.
	void growPointCounter () {
		growPoint += 1;
	}
}
