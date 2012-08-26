using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float wanderYaw = 0;
    private float wanderVal = 0;
    private float wanderCount = 0;
    private float wanderCountMax = 5f;
    private float wanderRandMax = 200;

    public float foeTurnRate = 180;

    public SeekPoint[] seekPointObject;
    public Vector3 seekPoint;
    private GameObject helper;

    public MoveObject myMoveObj;

    // Use this for initialization
    private void Awake()
    {
        helper = new GameObject();
        helper.transform.parent = gameObject.transform;

        myMoveObj = GetComponent<MoveObject>();
    }

    // Update is called once per frame
    private void Update()
    {
        myMoveObj.inYawRate = foeTurnRate;

        //WanderSphere();

        transform.Translate(0, 0, speed * Time.deltaTime);

        GameManager.WrapToScreen(gameObject);
    }

    /// <summary>
    ///  I am the spherical wandering function. I use a random point circeling a 
    /// sphere to impliment wandering
    /// </summary>
    private void WanderSphere()
    {
        // slowly move shift
        wanderCount -= Time.deltaTime;
        // only update wanderVal on timeed event
        if (wanderCount < 0)
        {
            wanderCount = wanderCountMax;
            wanderVal = Random.Range(-wanderRandMax, wanderRandMax);
        }
        wanderYaw += wanderVal * Time.deltaTime * Mathf.Cos(wanderCount * 6.28f / wanderCountMax); // sin added for smooth curve

        //if(wanderYaw < -180) wanderYaw+=360;
        //if(wanderYaw > 180) wanderYaw-=360;

        helper.transform.rotation = Quaternion.identity;
        helper.transform.Rotate(Vector3.up, wanderYaw); //+myMoveObj.curYaw

        seekPoint = transform.position + helper.transform.forward * 10f;
       // transform.LookAt(helper.transform);
    }
}
