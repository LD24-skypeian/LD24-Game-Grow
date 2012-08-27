using UnityEngine;

public class SideScrollingController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject Player;

    public float Distance=15.0f;

    void Awake()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        Player = GameObject.FindWithTag("Player");

    }

    void Start()
    {
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z - Distance);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up);
        }
    }

}