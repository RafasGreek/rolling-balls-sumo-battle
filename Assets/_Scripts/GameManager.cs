using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] int scoreToEnd = 7; //Score needed for the game to end
    [Space]
    [SerializeField] int player1Score;
    [SerializeField] int player2Score;

    public event Action<int, int> OnPlayerScored;

    [Space]
    [SerializeField] Transform player1;
    [SerializeField] Transform player2;
    [Space]
    [SerializeField] Transform player1Spawn;
    [SerializeField] Transform player2Spawn;
    [Space]
    [SerializeField] float resetYPosition = -10;
    [Space]
    [SerializeField] GameObject endCanvas;
    [SerializeField] GameObject player1WinsText;
    [SerializeField] GameObject player2WinsText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (player1.position.y < resetYPosition)
        {
            player2Score++;
            OnPlayerScored?.Invoke(player1Score, player2Score);
            SpawnPlayers();
        }
        else if (player2.position.y < resetYPosition)
        {
            player1Score++;
            OnPlayerScored?.Invoke(player1Score, player2Score);
            SpawnPlayers();
        }

        if (player1Score == scoreToEnd || player2Score == scoreToEnd)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        player1.GetComponent<Rigidbody>().isKinematic = true;
        player2.GetComponent<Rigidbody>().isKinematic = true;

        endCanvas.SetActive(true);

        if (player1Score > player2Score)
        {
            player1WinsText.SetActive(true);
        }
        else
        {
            player2WinsText.SetActive(true);
        }
    }

    void SpawnPlayers()
    {
        player1.position = player1Spawn.position;
        player1.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        player1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        player2.position = player2Spawn.position;
        player2.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        player2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
