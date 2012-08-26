using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
	public int bulletSpeed = 10;
	public int bulletDamage = 0;
	
	public Vector3 bulletMaxDistance;
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate(Vector3.forward * (bulletSpeed * Time.deltaTime));
	}
	
	void OnCollisionEnter (Collision other){
		if (other.gameObject.collider){
			bulletDamage = 5;
			Destroy(this);
		}
	}
	
}
