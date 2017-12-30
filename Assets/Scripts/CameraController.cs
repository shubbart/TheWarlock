using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;

	void Start ()
    {
        offset = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
        transform.position = player.transform.position + offset;
	}
}
