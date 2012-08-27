using UnityEngine;

//Have this script add up the total of growPoints.

public class growPoints : MonoBehaviour
{
    public static int GrowPoints;
    public static int FoodCount;

    public int GrowPointRate = 2;

    public int GrowPointCount;
    public int FoodCountCount;

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
    }
}