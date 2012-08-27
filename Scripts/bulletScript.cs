using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
	public int bulletSpeed = 10;
	public int bulletDamage = 0;
	public float bulletLife = 3f;

	public Vector3 bulletDirection;
	
	void Start () {
		GameManager.RotateToMouse(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(0, 0, -(bulletSpeed * Time.deltaTime));

		bulletLife -= Time.deltaTime;
		if (bulletLife <= 0)
			Destroy(this.gameObject);
	}
	
	void OnCollisionEnter (Collision other){
		if (other.gameObject.collider){
			bulletDamage = 5;
			Destroy(this);
		}
	}
	
}
