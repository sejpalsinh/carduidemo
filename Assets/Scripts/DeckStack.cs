using System.Collections.Generic;
using UnityEngine;

public class DeckStack : MonoBehaviour
{
    [SerializeField] int _deckMaxSize;
    [SerializeField] GameManager _gameManager;
    private Stack<Card> deck;
    private bool _isStackFull;

    // Start is called before the first frame update
    void Start()
    {
        deck = new Stack<Card>();
    }

    
    // Add new card and if value is same make upper card double
    public void AddCardToDeck(Card newCard,int _sameCardIteration)
    {
        newCard.DisbaleMoveing();
        if (deck.Count == 0)
        {
            if(newCard.GetCardType() == CardType.NORMAL || newCard.GetCardType() == CardType.BOMB)
            {
                SetNewCardPosition(newCard);
                deck.Push(newCard);
            }
            else
            {
                Destroy(newCard.gameObject);
            }
        }
        else
        {
            if ( newCard.GetCardType() == CardType.NORMAL || newCard.GetCardType() == CardType.BOMB)
            {
                if (newCard.GetCardValue() == deck.Peek().GetCardValue())
                {
                    if(newCard.GetCardType() == CardType.BOMB || deck.Peek().GetCardType() == CardType.BOMB)
                    {
                        int scoreForBombCard = newCard.GetCardValue();
                        Destroy(newCard.gameObject);
                        while(deck.Count > 0)
                        {
                            Card tempCard = deck.Pop();
                            scoreForBombCard = scoreForBombCard + tempCard.GetCardValue();
                            print(tempCard.GetCardValue());
                            Destroy(tempCard.gameObject);
                        }
                        _gameManager.UpdateScore(scoreForBombCard);
                    }
                    else
                    {
                        Destroy(newCard.gameObject);
                        Card tempCard = deck.Pop();
                        _sameCardIteration = _sameCardIteration + 1;
                        tempCard.SetCardValue(tempCard.GetCardValue() * 2);
                        //print(_sameCardIteration+" "+tempCard.GetCardValue());
                        _gameManager.UpdateScore(tempCard.GetCardValue() * _sameCardIteration);
                        AddCardToDeck(tempCard, _sameCardIteration);
                    }
                }
                else
                {
                    SetNewCardPosition(newCard);
                    deck.Push(newCard);
                }
                if (deck.Count == _deckMaxSize)
                {
                    _isStackFull = true;
                }
                else
                {
                    _isStackFull = false;
                }
            }
            if( newCard.GetCardType() == CardType.RAT)
            {
                // Remove new card and destroy half of deck and add total score to Scoreboard
                Destroy(newCard.gameObject);
                int scoreForRatCard = 0;
                int deckSize = deck.Count;
                for (int loopCounter = 0; loopCounter < deckSize / 2; loopCounter++)
                {
                    Card tempCard = deck.Pop();
                    scoreForRatCard = scoreForRatCard + tempCard.GetCardValue();
                    Destroy(tempCard.gameObject);
                }
                _gameManager.UpdateScore(scoreForRatCard);
            }
            if (newCard.GetCardType() == CardType.WILD)
            {
                // Chnage new card's value to first card's value
                int newValue = GetTopCardValue();
                if (newValue == 0)
                {
                    newValue = 2; // If it's only card in deck set 2 value to card and set it in to deck.
                }
                newCard.SetCardValue(newValue);
                newCard.SetCardType(CardType.NORMAL);
                AddCardToDeck(newCard, _sameCardIteration);
            }
            if (newCard.GetCardType() == CardType.NUMBERCHANGER)
            {
                // Remove new Card and change value of first card's to value of second card's value. 
                Card tempCard = deck.Pop();
                int newValue = GetTopCardValue();
                if(newValue == 0)
                {
                    newValue = tempCard.GetCardValue(); // If it's only card in deck set own value to card and set it in to deck again.
                }
                tempCard.SetCardValue(newValue);
                Destroy(newCard.gameObject);
                AddCardToDeck(tempCard, _sameCardIteration);
            }
        }
    }

    // Get position of top card and is deck is empty return starting place.
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


    // If stack is full but last card is same, Allow Player to add card.
    public bool IsCardAllowInDeck(int cardVal,CardType cardType)
    {
        if (_isStackFull)
        {
            if (cardVal == GetTopCardValue() || (cardType != CardType.NORMAL && cardType != CardType.BOMB) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }

    // Return value of top card from deck.
    public int GetTopCardValue()
    {
        if (deck.Count == 0)
        {
            return 0;
        }
        return deck.Peek().GetCardValue();
    }
}
