using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    private float _setCountDown = 3f;
    private float _countDown;
    

    private void Awake()
    {
        _countDown = _setCountDown;
        foreach (Transform child in transform)
        {
            child.Rotate(new Vector3(0, Random.Range(-360f, 360f), 0));
        }
    }
    
    // Update is called once per frame
    private void Update()
    {
        if(_countDown >= 0)
            _countDown -= Time.deltaTime;

        if (_countDown <= 0)
        {
            foreach (Transform child in transform)
            {
                child.Rotate(new Vector3(0, Random.Range(-360f, 360f), 0));
            }
            _countDown = _setCountDown;
        }

        if (transform.childCount == 0)
        {
            Application.LoadLevel("Credits");
        }

    }
}