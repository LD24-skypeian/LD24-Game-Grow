using UnityEngine;

public class evolutionPoints : MonoBehaviour
{

    public GameObject player;
    public Transform target;
    public int totalEvolutionsPoints = 0;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void evolutionCounter()
    {
        totalEvolutionsPoints += 1;
    }
}