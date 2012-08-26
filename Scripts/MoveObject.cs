/// <summary>
/// I am basic movement object. I should be attached to any object that can 
/// move under its own power arround tha game world. This must be attached to 
/// an ovject with a character controller
/// </summary>

using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float inputDx;	//-1 to 1
    public float inputDy;	// -1 to 1
    public float inMoveRate = 10;

    public float inYawRate = 400;
    private float inYawMoveThreshold = 10;

    private float _inAccelerate = 10;

    private float _curYaw = 5;

    public float CurYaw { get { return _curYaw; } set { _curYaw = value; } }

    public bool isFacing;
    CharacterController myCharacter;

    // Use this for initialization
    void Start()
    {
        myCharacter = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateYaw();
        UpdateMove();

    }

    void UpdateYaw()
    {
        Vector3 inDelta = new Vector3(inputDx, 0, inputDy);
        Vector3 localWant = transform.InverseTransformDirection(inDelta);
        //Vector3 localWant = transform.InverseTransformDirection(curHeading);
        if (Vector3.Angle(Vector3.forward, localWant) > inYawMoveThreshold && localWant.magnitude > 0)
        {
            if (localWant.x < 0)
            {
                _curYaw -= inYawRate * Time.deltaTime;
            }
            else
            {
                _curYaw += inYawRate * Time.deltaTime;
            }
        }
        if (_curYaw < -180) _curYaw += 360;
        if (_curYaw > 180) _curYaw -= 360;
        transform.rotation = Quaternion.identity;
        transform.Rotate(Vector3.up, _curYaw);


    }

    void UpdateMove()
    {
        Vector3 inDelta = new Vector3(inputDx, 0, inputDy);
        Vector3 localWant = transform.InverseTransformDirection(inDelta);
        isFacing = false;
        if (Vector3.Angle(Vector3.forward, localWant) > inYawMoveThreshold) return;
        isFacing = true;
        //myCharacter.Move(transform.forward*inMoveRate*Time.deltaTime);
        //return;
        // add slight downward force of above 0 y
        if (myCharacter.enabled == true)
        {
            if (transform.position.y > 0)
            {
                myCharacter.Move(transform.forward * inMoveRate * Time.deltaTime + Vector3.up * -10 * Time.deltaTime);
            }
            else
            {
                // force to y 
                myCharacter.Move(transform.forward * inMoveRate * Time.deltaTime);
            }
        }
    }
}