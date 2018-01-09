using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iDamageable
{
    float DamageMinusArmor(float damageDealt);
    void TakeDamage(float damage);
    void Die();
}
