using UnityEngine;

public class playerEnergy : MonoBehaviour
{
    private int energy = 0; // an adjustable amount of energy that is affected by Constant gameplay.

    public int maxEnergy = 50; //the maximum amount of energy the player will have.
    public int bulletEnergy = 5;
    public int healthLoss;

    public float _energyLossTime = 3f;
    public float _coolDown = 3f;
    public float maxTimeEnergy = 2f;
    public float timeEnergy;

    public foodPills energyFood;
    private playerHealth pHealth;

    public int Energy
    {
        get { return energy; }
        set { energy = value; }
    }

    private void Awake()
    {
        //energyFood = GameObject.FindWithTag("food").GetComponent<foodPills>();
        pHealth = gameObject.GetComponent<playerHealth>();
    }

    private void Start()
    {
        energy = 100;
    }

    private void Update()
    {
        if (energy > maxEnergy)
            energy = maxEnergy;
        energyLoss();
        playerSpeed();
        if (energy < 0)
            energy = 0;

        if (_energyLossTime > 0)
            _energyLossTime -= Time.deltaTime;
        if (_energyLossTime < 0)
            _energyLossTime = 0f;
        if (_energyLossTime == 0)
        {
            _energyLossTime = _coolDown;
            playerHealthLoss();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (energy != maxEnergy)
        {
            if (other.gameObject.tag == "food")
            {
                energy = energy + energyFood.energyPills;
            }
        }
    }

    private void energyLoss()
    {
        //Debug.Log("isMoving: " + TadPoleMovementController.isMoving);

        if (TadPoleMovementController.isMoving)
        {
            timeEnergy -= Time.deltaTime;
        }

        if (timeEnergy < 0f)
        {
            energy -= 1;
            timeEnergy = maxTimeEnergy;
        }

        if (energy <= 0f)
        {
            energy = 0;
            TadPoleMovementController.speed = TadPoleMovementController.baseSpeed * .15f;
        }

        if ((gameObject.GetComponentInChildren<playerShoot>().isCreated == false) && (energy > 5))
        {
            energy -= bulletEnergy;
        }

    }

    private void playerHealthLoss()
    {

        if (energy > 20)
        {
            healthLoss = 0;
        }
        if (energy < 20)
        {
            healthLoss = 2;
            pHealth.Health -= healthLoss;
        }
        if (energy < 10)
        {
            healthLoss = 3;
            pHealth.Health -= healthLoss;
        }
        if (energy < 5)
        {
            healthLoss = 4;
            pHealth.Health -= healthLoss;
        }
    }

    private void playerSpeed()
    {
        if (energy > 20)
        {
            TadPoleMovementController.speed = TadPoleMovementController.baseSpeed;
        }
        else if (energy <= 20 && energy >= 10)
        {
            TadPoleMovementController.speed = TadPoleMovementController.baseSpeed * .75f;
        }
        else if (energy <= 10 && energy >= 5)
        {
            TadPoleMovementController.speed = TadPoleMovementController.baseSpeed * .50f;
        }
        else
        {
            TadPoleMovementController.speed = TadPoleMovementController.baseSpeed * .25f;
        }
    }
}