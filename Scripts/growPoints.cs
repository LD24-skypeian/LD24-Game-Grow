using UnityEngine;

//Have this script add up the total of growPoints.

public class growPoints : MonoBehaviour
{
    public static int GrowPoints;
    public static int FoodCount;

    public int GrowPointRate = 2;

    public int GrowPointCount;
    public int FoodCountCount;

    private int _growTimes;

    private bool _leveledUp;
    void Update()
    {
        // debug to show in the inspector
        
        GrowPointCount = GrowPoints;
        FoodCountCount = FoodCount;

        if (FoodCount == GrowPointRate)
        {
            GrowPoints++;
            FoodCount = 0;
        }

        if (GrowPoints == 2)
        {
            _growTimes++;
            gameObject.transform.localScale *= 1.2f;
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            GrowPoints = 0;
            _leveledUp = false;
        }
        if (_growTimes % 2 == 1 && !_leveledUp)
        {
            _leveledUp = true;
            gameObject.GetComponentInChildren<playerShoot>().Bullet.GetComponent<bulletScript>().bulletDamage *= 1.5f;
        }
    }
}