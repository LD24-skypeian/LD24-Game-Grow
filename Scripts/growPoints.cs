using UnityEngine;

//Have this script add up the total of growPoints.

public class growPoints : MonoBehaviour
{
    private float timer = 0f;
    private float coolDown = 6.0f;
    public static int GrowPoints = 0; //the grow points

    private void Update()
    {
        timeUntilGP();
    }
	
    //if the player hits something, it resets the counter, otherwise, after 6 seconds, the player gains a GP
    private void timeUntilGP()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            timer = 0f;
        }

        if (timer <= 0)
        {
            timer = coolDown;
            growPointCounter();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Contains("Enemy"))
            timer = coolDown;
    }

    //player gains GP.
    private void growPointCounter()
    {
        GrowPoints += 1;
    }
}