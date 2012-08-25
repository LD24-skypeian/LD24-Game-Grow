using UnityEngine;

[RequireComponent(typeof (CharacterController))]
public class TadPoleMovementController : MonoBehaviour
{
    public Camera fixedCamera;

    public float speed = 10.0f;
    public float rotateSpeed = 6.0f;

    public float cameraHeight = 50f;
    public float cameraSpeed = 10.0f;

    private void Update()
    {
        float adjustedRotateSpeed = rotateSpeed * 10.0f;

        //float x = Input.GetAxis("Horizontal") * Time.smoothDeltaTime * speed;
        //float y = Input.GetAxis("Vertical") * Time.smoothDeltaTime * speed;

        #region Forward/Backward

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime, Space.Self);
        }

        #endregion

        #region Rotate

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -adjustedRotateSpeed * Time.deltaTime, 0, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, adjustedRotateSpeed * Time.deltaTime, 0, Space.Self);
        }

        #endregion

        Vector3 newPosition = gameObject.transform.position;
        newPosition.y = cameraHeight;

        fixedCamera.transform.position = newPosition; //Vector3.Lerp(fixedCamera.transform.position, newPosition, Time.deltaTime * cameraSpeed);

        fixedCamera.transform.LookAt(gameObject.transform);
    }
}