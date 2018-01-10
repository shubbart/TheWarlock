using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : MonoBehaviour
{
    [SerializeField] float baseDamage;
    [SerializeField] float duration;
    float spellPower;
    GameObject player;
    PlayerCharacterSheet pSheet;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spellPower = player.GetComponent<PlayerCharacterSheet>().player.spellPower;
        pSheet = player.GetComponent<PlayerCharacterSheet>();
	}

    private void Update()
    {
        duration -= Time.deltaTime;

        if(duration <= 0)
           Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemySheet>().TakeDamage(baseDamage + spellPower);
            Debug.Log("Enemy remaining HP: " + collision.gameObject.GetComponent<EnemySheet>().enemy.currentHealth);
            Destroy(gameObject);
        }
    }
}
