using UnityEngine;
using System.Collections;

public class RockParent : MonoBehaviour
{
	
	void Awake()
	{
	    foreach (Transform child in transform)
	    {
	        child.gameObject.AddComponent<Rock>();
	    }
	}
}
