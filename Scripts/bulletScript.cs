using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int bulletSpeed = 10;
    public float bulletDamage = 0;
    public float bulletLife = 3f;

    public Vector3 bulletDirection;

    private void Start()
    {
        GameManager.RotateToMouse(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        gameObject.transform.Translate(0, 0, -(bulletSpeed * Time.deltaTime));

        bulletLife -= Time.deltaTime;
        if (bulletLife <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.collider)
        {
            bulletDamage = 5;
            Destroy(gameObject);
        }
    }
}