using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject spellBeingDragged;
    Vector3 startPosition;
    Transform startParent;

    public Ability spell;

    void Start()
    {
        GetComponent<Image>().sprite = spell.aSprite;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        spellBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        spellBeingDragged = null;

        transform.position = startPosition;
    }
}
