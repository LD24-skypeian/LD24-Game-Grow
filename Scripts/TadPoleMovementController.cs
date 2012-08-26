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

    private Animation myAnimation;

    private void Awake()
    {
        Top = GameObject.Find("Top").GetComponent<BoxCollider>();
        Bot = GameObject.Find("Bottom").GetComponent<BoxCollider>();
        Left = GameObject.Find("Left").GetComponent<BoxCollider>();
        Right = GameObject.Find("Right").GetComponent<BoxCollider>();

        myAnimation = GetComponentInChildren<Animation>();
    }

    private void Update()
    {
        Movement();

        GameManager.RotateToMouse(gameObject);

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

        if (Input.GetKey(KeyCode.W) || Input.GetMouseButton(0))
        {
            transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
            //myAnimation.animation.Play();
        }

        //else if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(0, 0, -speed * Time.deltaTime, Space.Self);
        //}
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

    

}