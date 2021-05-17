using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Moveable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] DeckStackHolder _deckStackHolder;
    [SerializeField] Card _thisCard;
    private bool _isDragging;
    // Onclick on object stop object from moving
    public void OnBeginDrag(PointerEventData eventData)
    {
        _isDragging = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Tuple<bool, DeckStack> isAnyNearCard = _deckStackHolder.GetNearestDeckIfAny(_thisCard.GetPosition(), _thisCard.GetCardValue(), _thisCard.GetCardType());
        if (isAnyNearCard.Item1)
        {
            // Write logic of highlighting card
        }
        transform.position = eventData.position;
    }
    // On Drag stop check all pair and object is at right place or not if not move to dustbin
    public void OnEndDrag(PointerEventData eventData)
    {
        Tuple<bool, DeckStack> isAnyNearCard = _deckStackHolder.GetNearestDeckIfAny(_thisCard.GetPosition(), _thisCard.GetCardValue(), _thisCard.GetCardType());
        if (isAnyNearCard.Item1)
        {
            isAnyNearCard.Item2.AddCardToDeck(_thisCard,0);
        }
        //print("Drag End");
    }
}
