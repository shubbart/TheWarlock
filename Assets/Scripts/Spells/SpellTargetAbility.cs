using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/SpellTargetAbility")]
public class SpellTargetAbility : Ability
{
    public GameObject spellEffect;

    private SpellTargetTrigger cast;

    public override void Initialize(GameObject obj)
    {
        cast = obj.GetComponent<SpellTargetTrigger>();
        cast.spellEffect = spellEffect;
    }

    public override void TriggerAbility()
    {
        cast.CastSpell();
    }
}
