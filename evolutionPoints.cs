using UnityEngine;
using System.Collections;

public class evolutionPoints : MonoBehaviour {
	
	public GameObject player;
	public Transform target;
	public int totalEvolutionsPoints = 0;
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void evolutionCounter(){
		totalEvolutionsPoints += 1;
	}
}
