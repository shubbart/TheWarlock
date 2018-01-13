using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSelfTrigger : MonoBehaviour
{
    private Transform spawnLocation;
    [HideInInspector] public GameObject spell;

    public void CastSpell()
    {
        spawnLocation = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject spellCopy = Instantiate(spell, spawnLocation.position, spell.transform.rotation) as GameObject;
    }
}
