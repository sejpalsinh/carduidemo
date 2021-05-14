using System;
using TMPro;
using UnityEngine;

public enum CardType
{
    NORMAL,
    BOMB, // Will blast each card in column and add total to Score
    WILD, // Will Convert new card's value to first card value from deck 
    RAT, // Will remove half card in column and add total of removed card's to Score
    NUMBERCHANGER // Will Convert first card of deck's value to second card's value 
}

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _cardValue;
    [SerializeField] private CardType _cardType;
    [SerializeField] private Moveable _moveable;
    [SerializeField] TextMeshProUGUI _leftUpperNumberTmp;
    [SerializeField] TextMeshProUGUI _centerNumberTmp;
    
    // Set card number to card
    void Start()
    {
        if(_cardType == CardType.NORMAL)
        {
            _leftUpperNumberTmp.SetText(_cardValue.ToString());
            _centerNumberTmp.SetText(_cardValue.ToString());
        }
        if(_cardType == CardType.BOMB)
        {
            _leftUpperNumberTmp.SetText(_cardValue.ToString());
        }
    }

    // Change card value
    public void SetCardValue(int cardVal)
    {
        _cardValue = cardVal;
        _leftUpperNumberTmp.SetText(cardVal.ToString());
        _centerNumberTmp.SetText(cardVal.ToString());
    }

    // Return value of card
    public int GetCardValue()
    {
        return _cardValue;
    }

    // Set position of card
    public void SetPosition(Vector2 _newPos)
    {
        transform.position = _newPos;
    }

    // Get current position of card
    public Vector2 GetPosition()
    {
        return transform.position;
    }
    // Remove moveable script from card so player can not drag
    public void DisbaleMoveing()
    {
        Destroy(_moveable);
    }

    public CardType GetCardType()
    {
        return _cardType;
    }
    public void SetCardType(CardType _newType)
    {
        _cardType = _newType;
    }
}
