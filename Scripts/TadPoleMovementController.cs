using UnityEngine;

[RequireComponent(typeof (CharacterController))]
[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (playerHealth))]
[RequireComponent(typeof (playerEnergy))]
public class TadPoleMovementController : MonoBehaviour
{

    public static bool isMoving;

    public Camera fixedCamera;

    public static float speed = 10.0f;
    public static float baseSpeed = 10.0f;

    public float cameraHeight = 50f;
    public float cameraSpeed = 10.0f;

    private BoxCollider Top;
    private BoxCollider Bot;
    private BoxCollider Left;
    private BoxCollider Right;

    private void Awake()
    {
        Top = GameObject.Find("Top").GetComponent<BoxCollider>();
        Bot = GameObject.Find("Bottom").GetComponent<BoxCollider>();
        Left = GameObject.Find("Left").GetComponent<BoxCollider>();
        Right = GameObject.Find("Right").GetComponent<BoxCollider>();
    }

    private void Update()
    {
        Movement();

        RotateToMouse();

        WrapToScreen();
    }

    private void WrapToScreen()
    {
        if (gameObject.transform.position.z > Top.transform.position.z)
            transform.position = new Vector3(transform.position.x, transform.position.y, Bot.transform.position.z + 5.0f);
        else if(gameObject.transform.position.z < Bot.transform.position.z)
            transform.position = new Vector3(transform.position.x, transform.position.y, Top.transform.position.z - 5.0f);
        else if(gameObject.transform.position.x < Left.transform.position.x)
            transform.position = new Vector3(Right.transform.position.x - 5.0f, transform.position.y, transform.position.z);
        else if (gameObject.transform.position.x > Right.transform.position.x)
            transform.position = new Vector3(Left.transform.position.x + 5.0f, transform.position.y, transform.position.z);
    }

    private void Movement()
    {
        #region Forward/Backward

        isMoving = true;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime, Space.Self);
        }
        else
        {
            isMoving = false;
        }

        #endregion

        Vector3 newPosition = gameObject.transform.position;
        newPosition.y = cameraHeight;

        fixedCamera.transform.position = newPosition; //Vector3.Lerp(fixedCamera.transform.position, newPosition, Time.deltaTime * cameraSpeed);

        fixedCamera.transform.LookAt(gameObject.transform);
    }

    private void RotateToMouse()
    {
        //Veriables
        Vector3 ScreenMouse;

        //Get Mouse Point ON screen
        ScreenMouse.x = Input.mousePosition.x;
        ScreenMouse.y = Input.mousePosition.y;
        ScreenMouse.z = 1;

        //Get Mouse Point In World
        var WorldMouse = Camera.main.ScreenToWorldPoint(ScreenMouse);

        WorldMouse.y = transform.position.y;

        //Get Angle Of Mouse From Ship Position
        transform.LookAt(WorldMouse);
    }

}