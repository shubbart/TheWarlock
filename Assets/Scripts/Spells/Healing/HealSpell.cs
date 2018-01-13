using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpell : MonoBehaviour
{
    [SerializeField] float baseHeal;
    [SerializeField] Vector3 offset;
    float spellPower;
    GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spellPower = player.GetComponent<PlayerCharacterSheet>().player.spellPower;
        player.GetComponent<PlayerCharacterSheet>().HealingReceived(baseHeal + spellPower);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = player.transform.position + offset;
	}
}
