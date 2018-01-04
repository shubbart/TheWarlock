using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSheet : MonoBehaviour, iHeal, iDamageable
{
    struct PlayerSheet
    {
        public string name;
        public float maxHealth;
        public float currentHealth;
        public float maxMana;
        public float currentMana;
        public float armorValue;

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

    PlayerSheet player;

	void Start ()
    {
        player.strMod = (player.Str - 10) / 2;
        player.dexMod = (player.Dex - 10) / 2;
        player.conMod = (player.Con - 10) / 2;
        player.intMod = (player.Int - 10) / 2;
        player.wisMod = (player.Wis - 10) / 2;

        player.maxHealth = 20 + player.conMod;
        player.maxMana = 20 + 2 * player.intMod;

        player.currentHealth = player.maxHealth;
        player.currentMana = player.maxMana;

        player.armorValue = 0;

        player.attackPower = 1.25f * player.strMod;
        player.spellPower = 1.25f * player.intMod;

        player.attackSpeed = player.dexMod;
        player.statusResistance = player.conMod / 2;
        player.healthRecovery = player.conMod * 2;
        player.manaRecovery = player.wisMod * 3;

        player.healthRecoveryTime = 5;
        player.manaRecoveryTime = 8;



        player.healthRecoveryTimeReset = player.healthRecoveryTime;
        player.manaRecoveryTimeReset = player.manaRecoveryTime;
	}
	
	// Update is called once per frame
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

    public float DamageMinusArmor(float damageDealt)
    {
        return damageDealt * (1 - player.armorValue/10);
    }

    public void TakeDamage(float damage)
    {
        float dmg = DamageMinusArmor(damage);

        if (dmg <= 0)
            return;
        else
            player.currentHealth -= dmg;
    }

    public float HealingReceived(float heal)
    {
        return heal * player.healingModifier;
    }

    public void ApplyHealing(float heal)
    {
        player.currentHealth += HealingReceived(heal);
    }

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
}
