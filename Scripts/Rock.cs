using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour
{
    private void Update()
    {
        GameManager.WrapToScreen(gameObject);
    }
}