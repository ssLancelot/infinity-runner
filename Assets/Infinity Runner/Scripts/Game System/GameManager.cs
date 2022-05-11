using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] TMPro.TextMeshProUGUI _scoreText;
    [SerializeField] StarterTextUI _starterText;
    public static GameManager _instance;
    private void Awake()
    {
        _instance = this;
        gameData._isRunning = false;
        gameData._coinScore = 0;
        gameData._playerSpeed = gameData._playerStartSpeed;

    }
    private void Update()
    {
        if (Input.anyKey)
        {
            gameData._isRunning = true;
            _starterText._text.gameObject.SetActive(false);
        }
    }
    public void IncrementScore()
    {
        gameData._coinScore++;
        _scoreText.text = "Score: " + gameData._coinScore.ToString();
        gameData._playerSpeed += gameData._speedIncreasePerPoint;
    }
}
