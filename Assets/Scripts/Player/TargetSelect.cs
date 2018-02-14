using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelect : MonoBehaviour
{
    public Vector3 target;

    public bool targetEnemy;
    public bool targeting;
    public bool cancelled;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        // Is the spell active and targetting?
		if(targeting)
        {
            // Does the spell target an enemy or the ground?
            if (targetEnemy)
                TargetEnemy();
            else
                TargetGround();

            if(Input.GetMouseButton(1))
            {
                cancelled = true;
                targeting = false;
            }

        }
	}

    void Cancel()
    {

    }

    void TargetEnemy()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach(RaycastHit hit in hits)
            {
                if(hit.transform.gameObject.layer == 10)
                {
                    target = hit.transform.position;
                    targeting = false;
                    break;
                }
            }           
        }
    }

    void TargetGround()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.gameObject.layer == 8)
                {
                    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    target.y = 0;
                    Debug.Log(target);
                    targeting = false;
                    break;
                }
            }
        }
    }
}
