using UnityEngine;

public class SideScrollingController : MonoBehaviour
{
    public Camera mainCamera;

    public float Distance = 15.0f;
    public float jumpForce = 3.0f;

    private void Awake()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Start()
    {
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + 2.0f, transform.position.z - Distance);
    }

    private void Update()
    {
        GetKeys();

        ApplyGravity();
    }

    private void GetKeys()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * jumpForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0, 0, 1.0f);
        }
    }
}