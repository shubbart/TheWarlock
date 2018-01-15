using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellDrop : MonoBehaviour, IDropHandler
{
  
    public void OnDrop(PointerEventData eventData)
    {
 
        GetComponent<CoolDown>().ability = SpellDrag.spellBeingDragged.GetComponent<SpellDrag>().spell;
        GetComponent<CoolDown>().Initialize(GetComponent<CoolDown>().ability, GetComponent<CoolDown>().abilityHolder);
    }
}