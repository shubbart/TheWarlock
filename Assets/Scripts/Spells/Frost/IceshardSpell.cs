using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceshardSpell : MonoBehaviour
{
    [SerializeField] float baseDamage;
    [SerializeField] float duration;
    [SerializeField] float slowPercent;
    [SerializeField] float slowDuration;
    float spellPower;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spellPower = player.GetComponent<PlayerCharacterSheet>().player.spellPower;
    }

    private void Update()
    {
        duration -= Time.deltaTime;

        if (duration <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemySheet>().TakeDamage(baseDamage + spellPower);
            collision.gameObject.GetComponent<EnemySheet>().slowDuration = slowDuration;
            if (!collision.gameObject.GetComponent<EnemySheet>().isSlowed)
            {
                collision.gameObject.GetComponent<NavMeshAgent>().speed = collision.gameObject.GetComponent<NavMeshAgent>().speed * (1 - slowPercent / 100);
                collision.gameObject.GetComponent<EnemySheet>().isSlowed = true;
            }
           Debug.Log("Enemy remaining HP: " + collision.gameObject.GetComponent<EnemySheet>().enemy.currentHealth);
            Destroy(gameObject);
        }
    }
}
