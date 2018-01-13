using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/SpellSelfAbility")]
public class SpellSelfAbility : Ability
{
    public GameObject spell;
    private SpellSelfTrigger cast;

    public override void Initialize(GameObject obj)
    {
        cast = obj.GetComponent<SpellSelfTrigger>();
        cast.spell = spell;
    }

    public override void TriggerAbility()
    {
        cast.CastSpell();
    }
}
