using UnityEngine;

public class SideScrollingController : MonoBehaviour
{
    public Camera mainCamera;

    public float Distance = 15.0f;

    public float moveSpeed = 5.0f;
    public float jumpSpeed = 2.0f;
    public float gravity = 40.0f;

    private CharacterController charController;
    private Vector3 moveDir = Vector3.zero;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Start()
    {
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + 2.0f, transform.position.z - Distance);
    }

    private void Update()
    {
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, gameObject.transform.position.z - Distance);

        GetKeys();

        ApplyGravity();
    }

    private void GetKeys()
    {
        if (charController.isGrounded)
        {
            moveDir = new Vector3(-Input.GetAxis("Horizontal"), 0, 0);

            moveDir *= moveSpeed;

            if (moveDir.sqrMagnitude > 0.01f)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 1);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("JUMP");
                //moveDir.y += jumpSpeed * Time.deltaTime;
                //charController.Move(moveDir * Time.deltaTime);

                transform.Translate(Vector3.up * jumpSpeed);
            }


            //if (Input.GetKey(KeyCode.D))
            //{
            //    transform.Translate(0, 0, 1.0f);
            //}
        }
            moveDir.y -= gravity * Time.deltaTime;

            charController.Move(moveDir * Time.deltaTime);
        
    }

    private void ApplyGravity()
    {
        
    }
}