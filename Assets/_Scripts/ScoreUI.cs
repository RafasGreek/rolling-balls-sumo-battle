using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.OnPlayerScored += UpdateText;
        UpdateText(0, 0);
    }

    void UpdateText(int _player1Score, int _player2Score)
    {
        scoreText.SetText("<color=#007FFF>" + _player1Score + "</color> - <color=#FF2000>" + _player2Score + "</color>");
    }
}
