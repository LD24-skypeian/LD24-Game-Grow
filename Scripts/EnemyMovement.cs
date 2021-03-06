using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3.0f;

    // Use this for initialization
    private void Awake()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        GameManager.WrapToScreen(gameObject);
    }
}