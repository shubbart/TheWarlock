using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestruct : MonoBehaviour
{
    public float duration;
	// Use this for initialization
	void Start ()
    {
        Invoke("DestroySelf", duration);
	}
	
	void DestroySelf()
    {
        Destroy(gameObject);
    }
}
