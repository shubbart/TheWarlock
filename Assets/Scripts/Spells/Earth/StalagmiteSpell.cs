using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagmiteSpell : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float appliedForce;
    Rigidbody rbody;

    bool canDamage;

	void Start ()
    {
        Debug.Log(transform.position);
        transform.position = transform.position - new Vector3(0, -1, 0);
        rbody = GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0, appliedForce, 0);
        rbody.AddForce(force, ForceMode.Impulse);
	}
	
	void Update ()
    {
        if (rbody.velocity.y > 0)
            canDamage = true;
        else
            canDamage = false;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (canDamage && collision.gameObject.tag == "Enemy")
            collision.gameObject.GetComponent<EnemySheet>().TakeDamage(damage);
    }
}
