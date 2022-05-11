using UnityEngine;

[CreateAssetMenu(fileName = "new GameData")]
public class GameData : ScriptableObject
{
    [Header("Player Conf")]
    [SerializeField] internal bool _isRunning = false;
    [SerializeField] internal bool _alive = true;
    [SerializeField] internal float _playerStartSpeed = 5f;
    [SerializeField] internal float _playerSpeed = 5f;
    [SerializeField] internal float _speedIncreasePerPoint = 0.1f;
    [SerializeField] internal float _playerHorizontalSpeed = 7.5f;
    [SerializeField] internal float _internaLeft = -4.5f;
    [SerializeField] internal float _internalRight = 4.5f;
    [SerializeField] internal float _playerJumpForce = 400f;

    [Header("Tile Config")]
    [SerializeField] internal float _freeAreaDist = 15;
    [SerializeField][Range(0.1f, 1)] internal float _tallObstacleChance = 0.2f;

    [Header("Coin Conf")]
    [SerializeField] internal int _coinScore = 0;
    [SerializeField] internal int _coinPerTile = 3;
    [SerializeField] internal float _coinTurnSpeed = 90f;
}

