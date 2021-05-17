using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [Header("Card Generation Field")]
    [SerializeField] private Transform _nextCardPosition;
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private DeckStackHolder _deckStackHolder;
    [Header("Card Selection")]
    [SerializeField] private int _cardNumber2;
    [SerializeField] private int _cardNumber4;
    [SerializeField] private int _cardNumber8;
    [SerializeField] private int _cardNumber16;
    [SerializeField] private int _cardNumber32;
    [SerializeField] private int _cardNumber64;
    [SerializeField] private int _ratPowerCard;
    [SerializeField] private int _wildPowerCard;
    [SerializeField] private int _numberChnagerPowerCard;
    [SerializeField] private int[] _bombPowerCard;
    private GameObject[] _cardDeck;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.SetNewCard += SetNewCardFromDeck;
        _cardDeck = new GameObject[_cardNumber2+ _cardNumber4+ _cardNumber8+ _cardNumber16+ _cardNumber32+ _cardNumber64+ _ratPowerCard+ _wildPowerCard+ _numberChnagerPowerCard+ _bombPowerCard.Length];
        int _totalCards = 0;
        for (int loopCounter =0; loopCounter< _cardNumber2; loopCounter++)
        {
            _cardDeck[_totalCards++] = Instantiate(_cardPrefab.gameObject, transform);
            _cardDeck[_totalCards - 1].GetComponent<Card>().SetCardValue(2);
        }
        for (int loopCounter = 0; loopCounter < _cardNumber4; loopCounter++)
        {
            _cardDeck[_totalCards++] = Instantiate(_cardPrefab.gameObject, transform);
            _cardDeck[_totalCards - 1].GetComponent<Card>().SetCardValue(4);
        }
        for (int loopCounter = 0; loopCounter < _cardNumber8; loopCounter++)
        {
            _cardDeck[_totalCards++] = Instantiate(_cardPrefab.gameObject, transform);
            _cardDeck[_totalCards - 1].GetComponent<Card>().SetCardValue(8);
        }
        for (int loopCounter = 0; loopCounter < _cardNumber16; loopCounter++)
        {
            _cardDeck[_totalCards++] = Instantiate(_cardPrefab.gameObject, transform);
            _cardDeck[_totalCards - 1].GetComponent<Card>().SetCardValue(16);
        }
        for (int loopCounter = 0; loopCounter < _cardNumber32; loopCounter++)
        {
            _cardDeck[_totalCards++] = Instantiate(_cardPrefab.gameObject, transform);
            _cardDeck[_totalCards - 1].GetComponent<Card>().SetCardValue(32);
        }
        for (int loopCounter = 0; loopCounter < _cardNumber64; loopCounter++)
        {
            _cardDeck[_totalCards++] = Instantiate(_cardPrefab.gameObject, transform);
            _cardDeck[_totalCards - 1].GetComponent<Card>().SetCardValue(64);
        }
        for (int loopCounter = 0; loopCounter < _ratPowerCard; loopCounter++)
        {
            _cardDeck[_totalCards++] = Instantiate(_cardPrefab.gameObject, transform);
            _cardDeck[_totalCards - 1].GetComponent<Card>().SetCardValue(CardType.RAT);
        }
        for (int loopCounter = 0; loopCounter < _wildPowerCard; loopCounter++)
        {
            _cardDeck[_totalCards++] = Instantiate(_cardPrefab.gameObject, transform);
            _cardDeck[_totalCards - 1].GetComponent<Card>().SetCardValue(CardType.WILD);
        }
        for (int loopCounter = 0; loopCounter < _numberChnagerPowerCard; loopCounter++)
        {
            _cardDeck[_totalCards++] = Instantiate(_cardPrefab.gameObject, transform);
            _cardDeck[_totalCards - 1].GetComponent<Card>().SetCardValue(CardType.NUMBERCHANGER);
        }
        for (int loopCounter = 0; loopCounter < _bombPowerCard.Length; loopCounter++)
        {
            _cardDeck[_totalCards++] = Instantiate(_cardPrefab.gameObject, transform);
            _cardDeck[_totalCards - 1].GetComponent<Card>().SetCardValue(_bombPowerCard[loopCounter], CardType.BOMB);
        }
        SetNewCardFromDeck();
    }

    public void SetNewCardFromDeck()
    {
        if(_cardDeck.Length>0)
        {
            _cardDeck[_cardDeck.Length - 1].AddComponent<Moveable>();
            _cardDeck[_cardDeck.Length - 1].GetComponent<Moveable>().SetCard(_cardDeck[_cardDeck.Length - 1].GetComponent<Card>());
            _cardDeck[_cardDeck.Length - 1].GetComponent<Moveable>().SetDeckStackHolder(_deckStackHolder);
            _cardDeck[_cardDeck.Length - 1].transform.position = _nextCardPosition.position;
        }
        else
        {
            print("Deck Is Empty");
        }
    }
}
