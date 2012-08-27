using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GUISkin theGUI;

	private playerHealth pHealth;
	private playerEnergy pEnergy;
	private growPoints gPoints;
	//public int phealth;
	
	private static BoxCollider Top;
	private static BoxCollider Bot;
	private static BoxCollider Left;
	private static BoxCollider Right;

	private void Awake()
	{
		gPoints = GameObject.FindWithTag("Player").GetComponent<growPoints>();
		pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
		pEnergy = GameObject.FindGameObjectWithTag("Player").GetComponent<playerEnergy>();

		Top = GameObject.Find("Top").GetComponent<BoxCollider>();
		Bot = GameObject.Find("Bottom").GetComponent<BoxCollider>();
		Left = GameObject.Find("Left").GetComponent<BoxCollider>();
		Right = GameObject.Find("Right").GetComponent<BoxCollider>();
	}

	private void Update()
	{
	}

	private void OnGUI()
	{
		GUI.skin = theGUI;
		GUI.Label(new Rect(10, 10, 90, 20), "Health");
		GUI.Label(new Rect(100, 10, 90, 20), pHealth.Health.ToString());

		GUI.Label(new Rect(10, 30, 90, 20), "Energy");
		GUI.Label(new Rect(100, 30, 90, 20), pEnergy.Energy.ToString());

		GUI.Label(new Rect(10, 50, 90, 20), "Speed");
		GUI.Label(new Rect(100, 50, 90, 20), TadPoleMovementController.speed.ToString());

		GUI.Label(new Rect(10, 70, 90, 20), "Grow Points");
		GUI.Label(new Rect(100, 70, 90, 20), growPoints.GrowPoints.ToString());
	}

	public static void WrapToScreen(GameObject go)
	{
		if (go.transform.position.z > Top.transform.position.z)
			go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, Bot.transform.position.z + 5.0f);
		else if (go.transform.position.z < Bot.transform.position.z)
			go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, Top.transform.position.z - 5.0f);
		else if (go.transform.position.x < Left.transform.position.x)
			go.transform.position = new Vector3(Right.transform.position.x - 5.0f, go.transform.position.y, go.transform.position.z);
		else if (go.transform.position.x > Right.transform.position.x)
			go.transform.position = new Vector3(Left.transform.position.x + 5.0f, go.transform.position.y, go.transform.position.z);
	}

	public static void RotateToMouse(GameObject go)
	{
		//Veriables
		Vector3 ScreenMouse;

		//Get Mouse Point ON screen
		ScreenMouse.x = Input.mousePosition.x;
		ScreenMouse.y = Input.mousePosition.y;
		ScreenMouse.z = 1;

		//Get Mouse Point In World
		var WorldMouse = Camera.main.ScreenToWorldPoint(ScreenMouse);

		WorldMouse.y = go.transform.position.y;

		//Get Angle Of Mouse From Ship Position
		go.transform.LookAt(WorldMouse);
	}
}