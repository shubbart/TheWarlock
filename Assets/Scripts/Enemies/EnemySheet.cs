using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySheet : MonoBehaviour, iHeal, iDamageable
{
    public struct Enemy
    {
        public string name;
        public float maxHealth;
        public float currentHealth;
        public float maxMana;
        public float currentMana;
        public float armorValue;
        public float baseArmor;

        // Attributes
        public int Str, Dex, Con, Int, Wis;
        public int strMod, dexMod, conMod, intMod, wisMod;

        public float attackPower;
        public float spellPower;
        public float attackSpeed;
        public float statusResistance;
        public float healthRecovery;
        public float manaRecovery;
        public float healingModifier;

        public float healthRecoveryTime;
        public float healthRecoveryTimeReset;
        public float manaRecoveryTime;
        public float manaRecoveryTimeReset;
    }

    public Enemy enemy;
    NavMeshAgent self;

    public bool isSlowed;
    public float slowDuration;
    EnemyAttributes myAttributes;
    float originalSpeed;
    void Start()
    {
        // Construct the enemy sheet
        enemy = new Enemy();
        self = GetComponent<NavMeshAgent>();

        // Retrieves attributes from script
        myAttributes = GetComponent<EnemyAttributes>();

        SetAttributes();
        CompileEnemy();
        CheckAttributes();

        originalSpeed = self.speed;
    }

    void Update()
    {
        if (enemy.currentHealth <= 0)
            Die();

        if(isSlowed)
        {
            slowDuration -= Time.deltaTime;
            if(slowDuration <= 0)
            {
                self.speed = originalSpeed;
                isSlowed = false;
            }
        }
    }

    // Sets the attributes from the script inputs
    void SetAttributes()
    {
        enemy.name = myAttributes.newName;
        enemy.Str = myAttributes.Str;
        enemy.Dex = myAttributes.Dex;
        enemy.Con = myAttributes.Con;
        enemy.Int = myAttributes.Int;
        enemy.Wis = myAttributes.Wis;
    }

    // Do all the calculations for the character stats
    void CompileEnemy()
    {
        // Calculate modifiers based on Attributes
        enemy.strMod = (enemy.Str - 10) / 2;
        enemy.dexMod = (enemy.Dex - 10) / 2;
        enemy.conMod = (enemy.Con - 10) / 2;
        enemy.intMod = (enemy.Int - 10) / 2;
        enemy.wisMod = (enemy.Wis - 10) / 2;

        // Set maximum health and mana
        enemy.maxHealth = 20 + enemy.conMod;
        enemy.maxMana = 20 + 2 * enemy.intMod;

        // Set current health and mana to the max at the start of the game
        enemy.currentHealth = enemy.maxHealth;
        enemy.currentMana = enemy.maxMana;

        // Base armor value is 0
        enemy.baseArmor = 0;
        // Sets armor value to the base
        enemy.armorValue = enemy.baseArmor;

        // Calculate attack and spell power
        enemy.attackPower = 1.25f * enemy.strMod;
        enemy.spellPower = 1.25f * enemy.intMod;

        // Calculate attack speed
        enemy.attackSpeed = enemy.dexMod;

        // Calculate status effect resistance
        enemy.statusResistance = enemy.conMod / 2;

        // Calculate health and mana recovery
        enemy.healthRecovery = enemy.conMod * 2;
        enemy.manaRecovery = enemy.wisMod * 3;

        // Sets the passive health and mana recovery time.
        enemy.healthRecoveryTime = 5;
        enemy.manaRecoveryTime = 6.5f;

        // Sets the passive health and mana recovery time reset
        enemy.healthRecoveryTimeReset = enemy.healthRecoveryTime;
        enemy.manaRecoveryTimeReset = enemy.manaRecoveryTime;
    }

    // Debug to ensure that the attributes have been properly added and modifiers calculated
    public void CheckAttributes()
    {
        Debug.Log("Name: " + enemy.name);
        Debug.Log("Str: " + enemy.Str);
        Debug.Log("Dex: " + enemy.Dex);
        Debug.Log("Con: " + enemy.Con);
        Debug.Log("Int: " + enemy.Int);
        Debug.Log("Wis: " + enemy.Wis);

        Debug.Log("StrMod: " + enemy.strMod);
        Debug.Log("DexMod: " + enemy.dexMod);
        Debug.Log("ConMod: " + enemy.conMod);
        Debug.Log("IntMod: " + enemy.intMod);
        Debug.Log("WisMod: " + enemy.wisMod);

        Debug.Log("Max HP: " + enemy.maxHealth);
        Debug.Log("Max Mana: " + enemy.maxMana);
    }

    // Calculate damage received after armor deduction
    public float DamageMinusArmor(float damageDealt)
    {
        return damageDealt * (1 - enemy.armorValue / 10);
    }

    // Deal damage to the enemy's health
    public void TakeDamage(float damage)
    {
        float dmg = DamageMinusArmor(damage);

        if (dmg <= 0)
            return;
        else
            enemy.currentHealth -= dmg;
    }

    // Calculate the amount the enemy will heal
    public float HealingReceived(float heal)
    {
        return heal * enemy.healingModifier;
    }

    // Apply healing to the enemy's health
    public void ApplyHealing(float heal)
    {
        enemy.currentHealth += HealingReceived(heal);
    }

    // Apply passive healing to the enemy's health
    void PassiveHealtheRecover()
    {
        if (enemy.currentHealth < enemy.maxHealth)
        {
            if (enemy.currentHealth + enemy.healthRecovery <= enemy.maxHealth)
                enemy.currentHealth += enemy.healthRecovery;
            else
                enemy.currentHealth = enemy.maxHealth;
        }
    }

    // Apply the passive recovery of mana to the enemy's mana
    void PassiveManaRecovery()
    {
        if (enemy.currentMana < enemy.maxMana)
        {
            if (enemy.currentMana + enemy.manaRecovery <= enemy.maxMana)
                enemy.currentMana += enemy.manaRecovery;
            else
                enemy.currentMana = enemy.maxMana;
        }
    }

    public void Die()
    {
        Debug.Log(enemy.name + " has died!");
    }
}
