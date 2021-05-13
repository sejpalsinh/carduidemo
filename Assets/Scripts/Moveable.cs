using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Moveable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] DeckStackHolder _deckStackHolder;
    [SerializeField] Card _thisCard;
    private bool isDragging;
    // Onclick on object stop object from moving
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Tuple<bool, DeckStack> isAnyNearCard = _deckStackHolder.GetNearestDeckIfAny(_thisCard.GetPosition(), _thisCard.GetCardValue());
        if (isAnyNearCard.Item1)
        {
            
        }
        transform.position = eventData.position;
    }
    // On Drag stop check all pair and object is at right place or not if not move to dustbin
    public void OnEndDrag(PointerEventData eventData)
    {
        Tuple<bool, DeckStack> isAnyNearCard = _deckStackHolder.GetNearestDeckIfAny(_thisCard.GetPosition(), _thisCard.GetCardValue());
        if (isAnyNearCard.Item1)
        {
            isAnyNearCard.Item2.AddCardToDeck(_thisCard);
        }
        print("Drag End");
    }
}
