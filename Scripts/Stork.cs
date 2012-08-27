using UnityEngine;
using System.Collections;

public class Stork : MonoBehaviour
{
    void OnTriggerEnter()
    {
        gameObject.GetComponent<Animation>().Play();
    }
}