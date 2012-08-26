using UnityEngine;

public class foodPills : MonoBehaviour
{
    public int energyPills = 10;
    public int healthPills = 10;

    private playerHealth pHealth;

    private void Awake()
    {
        pHealth = GameObject.FindWithTag("Player").GetComponent<playerHealth>();
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("trigger tag:" + collider.gameObject.tag);
        if (collider.gameObject.tag.Contains("Player"))
        {
            playerHealthCheck();
            Destroy(gameObject);
        }
    }

    //checks if the player is at full hp, if he is, the energy pills will get all of the energy and health points.
    private void playerHealthCheck()
    {
        if (pHealth.health == pHealth.maxHealth)
        {
            energyPills = energyPills + healthPills;
        }
        //else
        //{
        //    energyPills = energyPills;
        //}
    }
}
