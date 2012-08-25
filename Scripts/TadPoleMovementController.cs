using UnityEngine;

[RequireComponent(typeof (CharacterController))]
public class TadPoleMovementController : MonoBehaviour
{
    public static bool isMoving;

    public Camera fixedCamera;

    public static float speed = 10.0f;
    public static float baseSpeed = 10.0f;
    public float rotateSpeed = 6.0f;

    public float cameraHeight = 50f;
    public float cameraSpeed = 10.0f;

    private void Update()
    {

        Movement();

        RotateToMouse();
        
    }

    private void Movement()
    {
       // float adjustedRotateSpeed = rotateSpeed * 10.0f;
        
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

        #region Rotate

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(0, -adjustedRotateSpeed * Time.deltaTime, 0, Space.Self);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(0, adjustedRotateSpeed * Time.deltaTime, 0, Space.Self);
        //}

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
        Vector3 ShipPos;

        //Get Mouse Point ON screen
        ScreenMouse.x = Input.mousePosition.x;
        ScreenMouse.y = Input.mousePosition.y;
        ScreenMouse.z = 1;

        //Get Mouse Point In World
        var WorldMouse = Camera.main.ScreenToWorldPoint(ScreenMouse);
        //Get Ship Position
        ShipPos = transform.position;

        WorldMouse.y = transform.position.y;

        //Get Angle Of Mouse From Ship Position
        transform.LookAt(WorldMouse);
    }
}