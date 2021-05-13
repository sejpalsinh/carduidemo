using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int cardValue;
    [SerializeField] private Moveable _moveable;
    [SerializeField] TextMeshProUGUI _leftUpperNumberTmp;
    [SerializeField] TextMeshProUGUI _centerNumberTmp;
    
    void Start()
    {
        _leftUpperNumberTmp.SetText(cardValue.ToString());
        _centerNumberTmp.SetText(cardValue.ToString());
    }

    // Change card value
    public void SetCardValue(int cardVal)
    {
        cardValue = cardVal;
        _leftUpperNumberTmp.SetText(cardVal.ToString());
        _centerNumberTmp.SetText(cardVal.ToString());
    }

    // Return value of card
    public int GetCardValue()
    {
        return cardValue;
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
}
