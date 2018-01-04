using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iHeal
{
    float HealingReceived(float heal);
    void ApplyHealing(float heal);
}
