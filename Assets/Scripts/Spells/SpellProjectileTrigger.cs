using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectileTrigger : MonoBehaviour
{
    [HideInInspector] public Rigidbody rbody;
    public Transform spawnLocation;
    [HideInInspector] public float projectileForce = 250f;

    public void CastSpell()
    {
        Rigidbody spellCopy = Instantiate(rbody, spawnLocation.position, transform.rotation) as Rigidbody;

        spellCopy.AddForce(spawnLocation.transform.forward * projectileForce);
    }
}
