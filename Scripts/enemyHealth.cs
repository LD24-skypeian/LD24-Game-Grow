using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int health = 10;

    public bulletScript bDamage;

    private void Start()
    {
        //bDamage = GameObject.FindWithTag("bullet").GetComponent<bulletScript>();
    }

    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
            health -= bDamage.bulletDamage;
    }
}
