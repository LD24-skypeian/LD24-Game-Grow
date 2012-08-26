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
    
    private Animation myAnimation;

    private void Awake()
    {

        myAnimation = GetComponentInChildren<Animation>();
    }

    private void Update()
    {
        Movement();

        GameManager.RotateToMouse(gameObject);

        GameManager.WrapToScreen(gameObject);
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