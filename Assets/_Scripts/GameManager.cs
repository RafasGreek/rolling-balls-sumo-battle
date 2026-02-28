using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
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
}
