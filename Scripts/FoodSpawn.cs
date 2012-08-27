using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public float countDown =1.0f;
    private float timer;

    public GameObject FoodFlake;

    // Use this for initialization
    void Start()
    {
        timer = countDown;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && transform.childCount == 0)
        {
            
            
            GameObject go = (GameObject) Instantiate(FoodFlake, transform.position, FoodFlake.transform.rotation);
            go.transform.parent = transform;

            timer = countDown;
        }

    }
}