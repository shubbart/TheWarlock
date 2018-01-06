using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/SpellProjectileAbility")]
public class SpellProjectileAbility : Ability
{
    public float projectileForce = 500f;
    public Rigidbody projRbody;

    //private ProjectilShootTriggerable launcher;

    public override void Initialize(GameObject obj)
    {
        //launcher = obj.GetComponent<ProjectilShootTriggerable>();
        //launcher.projectileForce = projectilForce;
        //launcher.rbody = projRbody;
        throw new System.NotImplementedException();
    }

    public override void TriggerAbility()
    {
        //launcher.Launch();
        throw new System.NotImplementedException();
    }
}
