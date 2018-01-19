using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastHandler : MonoBehaviour
{
    public void CastSpell()
    {
        GetComponent<PlayerController>().activeSlot.GetComponent<CoolDown>().ButtonTriggered();
    }
}
