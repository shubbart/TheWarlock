using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/SpellProjectileAbility")]
public class SpellProjectileAbility : Ability
{
    public float projectileForce = 500f;
    public Rigidbody projRbody;

    private SpellProjectileTrigger cast;

    public override void Initialize(GameObject obj)
    {
        cast = obj.GetComponent<SpellProjectileTrigger>();
        cast.projectileForce = projectileForce;
        cast.rbody = projRbody;
    }

    public override void TriggerAbility()
    {
        cast.CastSpell();
    }
}
