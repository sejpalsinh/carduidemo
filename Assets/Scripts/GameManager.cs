using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _gameScoreTmp;
    private static int GameScore;


    public void UpdateScore(int score)
    {
        GameScore += score;
        _gameScoreTmp.SetText(GameScore.ToString());
    }
}
