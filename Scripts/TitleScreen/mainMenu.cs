using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		if (GUI.Button(new Rect(10, 10, 100, 30), "Start")){
			Application.LoadLevel("Thomas");
		}
		if (GUI.Button(new Rect(10, 50, 100, 30), "Controls")){
			Application.LoadLevel("Controls");	
		}
	}
}
