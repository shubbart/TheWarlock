using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTargetTrigger : MonoBehaviour
{
    [HideInInspector] public GameObject spellEffect;
    [HideInInspector] public Vector3 targetLocation;

    public void CastSpell()
    {
        targetLocation = GameObject.FindObjectOfType<TargetSelect>().GetComponent<TargetSelect>().target;
        GameObject spellCopy = Instantiate(spellEffect, targetLocation, transform.rotation) as GameObject;
    }
}
