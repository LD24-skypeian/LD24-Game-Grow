using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class TadPoleMovementController : MonoBehaviour
{
	public Camera fixedCamera;

	public float speed = 10.0f;
	public float rotateSpeed = 20.0f;

	void Update () 
	{
		float x = Input.GetAxis("Horizontal") * Time.smoothDeltaTime * speed;
		float y = Input.GetAxis("Vertical") * Time.smoothDeltaTime * speed;

		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);           
		}

		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(0, 0, -speed * Time.deltaTime, Space.Self);
		}

		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(-speed * Time.deltaTime, 0, 0, Space.Self);
		}

		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(speed * Time.deltaTime, 0, 0, Space.Self);
		}
		
		if (Input.GetKey(KeyCode.Q))
		{
			transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0, Space.Self);
		}

		if (Input.GetKey(KeyCode.E))
		{
			transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.Self);
		}
	}
}
