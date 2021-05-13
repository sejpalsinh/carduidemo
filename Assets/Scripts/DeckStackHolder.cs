using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckStackHolder : MonoBehaviour
{
    [SerializeField] DeckStack[] _decks;
    [SerializeField] float _minDistance;

    // If any card is in range return nearest card
    public Tuple<bool, DeckStack> GetNearestDeckIfAny(Vector2 cardPosition, int cardVal)
    {
        bool isAnyDeckIsNear = false;
        float tempMinDistance = _minDistance;
        DeckStack nearestDeck = null;
        // Check distance from all deck's first card
        for (int loopCounter = 0; loopCounter< _decks.Length; loopCounter++)
        {
            float cardDistance = Vector2.Distance(cardPosition, _decks[loopCounter].GetPositionOfTopCard());
            if (cardDistance < tempMinDistance && !_decks[loopCounter].IsDeckFull(cardVal))
            {
                nearestDeck = _decks[loopCounter];
                tempMinDistance = cardDistance;
                isAnyDeckIsNear = true;
            }
        }
        return new Tuple<bool, DeckStack>(isAnyDeckIsNear, nearestDeck);
    }
}
