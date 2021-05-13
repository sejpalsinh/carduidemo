using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckStack : MonoBehaviour
{
    [SerializeField] int _deckMaxSize;
    private Stack<Card> deck;
    private bool isStackFull;

    // Start is called before the first frame update
    void Start()
    {
        deck = new Stack<Card>();
    }

    
    // Add new card and if value is same make upper card double
    public void AddCardToDeck(Card newCard)
    {
        newCard.DisbaleMoveing();
        if (deck.Count == 0)
        {
            SetNewCardPosition(newCard);
            deck.Push(newCard);
        }
        else
        {
            if (newCard.GetCardValue() == deck.Peek().GetCardValue())
            {
                Destroy(newCard.gameObject);
                Card tempCard = deck.Pop();
                tempCard.SetCardValue(tempCard.GetCardValue() * 2);
                AddCardToDeck(tempCard);
            }
            else
            {
                SetNewCardPosition(newCard);
                deck.Push(newCard);
            }
            if (deck.Count == _deckMaxSize)
            {
                isStackFull = true;
            }
            else
            {
                isStackFull = false;
            }
        }
    }

    // Get position of top card and is deck is empty return starting place
    public Vector2 GetPositionOfTopCard()
    {
        if(deck.Count == 0)
        {
            return transform.position;
            //return GetComponent<RectTransform>().anchoredPosition;
        }
        return deck.Peek().GetPosition();
    }


    // Set location for card
    private void SetNewCardPosition(Card newCard)
    {
        if (deck.Count == 0)
        {
            newCard.SetPosition(GetPositionOfTopCard());
        }
        else
        {
            newCard.SetPosition(new Vector2(GetPositionOfTopCard().x, GetPositionOfTopCard().y - 100));
        }
        newCard.transform.SetParent(gameObject.transform);
    } 


    // If stack is full but last card is same, Allow Player to add card
    public bool IsDeckFull(int cardVal)
    {
        return (isStackFull && cardVal != GetTopCardValue());
    }

    // Return value of top card from deck
    public int GetTopCardValue()
    {
        if (deck.Count == 0)
        {
            return 0;
        }
        return deck.Peek().GetCardValue();
    }
}
