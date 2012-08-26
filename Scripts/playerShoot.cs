using UnityEngine;
using System.Collections;

public class playerShoot : MonoBehaviour {
	public float attackTimer = 0.0f;
	public float coolDown = 2.0f;
	
	public GameObject Bullet;
	
	private TadPoleMovementController tadPoleMovement;
	
	void Awake () {
		tadPoleMovement = GameObject.Find ("Player").GetComponent<TadPoleMovementController>();
	}
	// Use this for initialization
	void Start () {
		attackTimer = 2.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (attackTimer > 0){
			attackTimer -= Time.deltaTime;
		}
		if (attackTimer < 0){
			attackTimer = 0;
		}
		if (Input.GetKey(KeyCode.Space)){
			if(attackTimer == 0){
				buttonToShoot();
				attackTimer = coolDown;
			}
		}
	}
	
	void buttonToShoot (){
		Instantiate(Bullet, transform.position, Quaternion.identity);
	}
}
