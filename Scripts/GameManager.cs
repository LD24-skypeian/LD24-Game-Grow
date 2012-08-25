using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GUISkin theGUI;

    private playerHealth pHealth;
    private playerEnergy pEnergy;

    private void Awake()
    {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        pEnergy = GameObject.FindGameObjectWithTag("Player").GetComponent<playerEnergy>();
    }

    private void OnGUI()
    {
        GUI.skin = theGUI;
        GUI.Label(new Rect(10, 10, 70, 40), "Health");
        GUI.Label(new Rect(80, 10, 70, 40), pHealth.health.ToString());

        GUI.Label(new Rect(10, 50, 70, 40), "Energy");
        GUI.Label(new Rect(80, 50, 70, 40), pEnergy.energy.ToString());

        //GUI.Label(new Rect(10, 100, 70, 40), "Timer");
    }
}
