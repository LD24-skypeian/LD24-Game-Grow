using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public bool isCreated = true;
    public float attackTimer = 0.0f;
    public float coolDown = 2.0f;

    private Vector3 playerPosition;
    private Vector3 targetPosition;

    public GameObject Bullet;

    public playerEnergy pEnergy;

    // Use this for initialization
    private void Start()
    {
        if (pEnergy == null)
            pEnergy = gameObject.transform.parent.GetComponentInChildren<playerEnergy>();

        if (Bullet == null)
            Bullet = GameObject.Find("Bullet");

        attackTimer = 2.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        //GameManager.RotateToMouse(gameObject);

        if (attackTimer > 0)
        {

            attackTimer -= Time.deltaTime;
            isCreated = true;
        }
        if (attackTimer < 0)
        {
            attackTimer = 0;
        }
        if ((Input.GetKey(KeyCode.Space)) && (pEnergy.Energy >= 5))
        {
            if (attackTimer == 0)
            {
                buttonToShoot();
                attackTimer = coolDown;
                isCreated = false;
            }
        }
    }

    private void buttonToShoot()
    {
        Instantiate(Bullet, transform.position, Quaternion.identity);
    }
}
