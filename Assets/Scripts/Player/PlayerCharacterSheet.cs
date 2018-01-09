using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSheet : MonoBehaviour, iHeal, iDamageable
{
    public struct PlayerSheet
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
    
    public PlayerSheet player;

	void Start ()
    {
        // Calculate modifiers based on Attributes
        player.strMod = (player.Str - 10) / 2;
        player.dexMod = (player.Dex - 10) / 2;
        player.conMod = (player.Con - 10) / 2;
        player.intMod = (player.Int - 10) / 2;
        player.wisMod = (player.Wis - 10) / 2;

        // Set maximum health and mana
        player.maxHealth = 20 + player.conMod;
        player.maxMana = 20 + 2 * player.intMod;

        // Set current health and mana to the max at the start of the game
        player.currentHealth = player.maxHealth;
        player.currentMana = player.maxMana;

        // Base armor value is 0
        player.baseArmor = 0;
        // Sets armor value to the base
        player.armorValue = player.baseArmor;

        // Calculate attack and spell power
        player.attackPower = 1.25f * player.strMod;
        player.spellPower = 1.25f * player.intMod;

        // Calculate attack speed
        player.attackSpeed = player.dexMod;

        // Calculate status effect resistance
        player.statusResistance = player.conMod / 2;

        // Calculate health and mana recovery
        player.healthRecovery = player.conMod * 2;
        player.manaRecovery = player.wisMod * 3;

        // Sets the passive health and mana recovery time.
        player.healthRecoveryTime = 5;
        player.manaRecoveryTime = 6.5f;

        // Sets the passive health and mana recovery time reset
        player.healthRecoveryTimeReset = player.healthRecoveryTime;
        player.manaRecoveryTimeReset = player.manaRecoveryTime;
	}
	
	void Update ()
    {
        // Passive HP and mana recovery
        player.healthRecoveryTime -= Time.deltaTime;
        player.manaRecoveryTime -= Time.deltaTime;
        if(player.healthRecoveryTime <= 0)
        {
            PassiveHealtheRecover();
            player.healthRecoveryTime = player.healthRecoveryTimeReset;
        }
        if (player.manaRecoveryTime <= 0)
        {
            PassiveManaRecovery();
            player.manaRecoveryTime = player.manaRecoveryTimeReset;
        }
    }

    // Calculate damage received after armor deduction
    public float DamageMinusArmor(float damageDealt)
    {
        return damageDealt * (1 - player.armorValue/10);
    }

    // Deal damage to the player's health
    public void TakeDamage(float damage)
    {
        float dmg = DamageMinusArmor(damage);

        if (dmg <= 0)
            return;
        else
            player.currentHealth -= dmg;
    }

    // Calculate the amount the player will heal
    public float HealingReceived(float heal)
    {
        return heal * player.healingModifier;
    }

    // Apply healing to the player's health
    public void ApplyHealing(float heal)
    {
        player.currentHealth += HealingReceived(heal);
    }

    // Apply passive healing to the player's health
    void PassiveHealtheRecover()
    {
        if (player.currentHealth < player.maxHealth)
        {
            if (player.currentHealth + player.healthRecovery <= player.maxHealth)
                player.currentHealth += player.healthRecovery;
            else
                player.currentHealth = player.maxHealth;
        }
    }

    // Apply the passive recovery of mana to the player's mana
    void PassiveManaRecovery()
    {
        if (player.currentMana < player.maxMana)
        {
            if (player.currentMana + player.manaRecovery <= player.maxMana)
                player.currentMana += player.manaRecovery;
            else
                player.currentMana = player.maxMana;
        }
    }

    public void Die()
    {

    }
}
