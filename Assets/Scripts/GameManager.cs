using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    private int score = 0;
    private bool isGameOver = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);   // hide at start
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;                 // pause game
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
