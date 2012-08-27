using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public int Damage = 10;
    public bool dealDamage;
    public float coolDown;
    public float initialCoolDown = 3.0f;

    public playerHealth pHealth;

    void Awake()
    {
        if (pHealth == null)
        {
            pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        }
    }

    private void Start()
    {
        dealDamage = false;
        coolDown = 3.0f;
    }

    private void Update()
    {

        if (coolDown > 0)
            coolDown -= Time.deltaTime;
        if (coolDown < 0)
            coolDown = 0f;
        if (coolDown == 0f)
        {
            dealDamage = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag.Contains("Player")) && (dealDamage))
        {
            Debug.Log("Trigger enemyDamage");
            pHealth.Health -= Damage;
            coolDown = initialCoolDown;
            dealDamage = false;
        }
    }
}