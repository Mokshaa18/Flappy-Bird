using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Data;
public class LogicScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int playerScore;
    public Text scoreText;

    public int highScore;
    public Text highScoreText;
    public AudioSource gameOverSound;
    public GameObject gameOverScreen;

    const string PREF_KEY = "HighScore";

    void Awake()
    {
        highScore = PlayerPrefs.GetInt(PREF_KEY, 0);
    }
    void Start()
    {

        if (scoreText == null) Debug.LogWarning("LogicScript: scoreText Not Assigned in Inspector");
        if (highScore == null) Debug.LogWarning("LogicScript: HighScoreText Not Assigned in Inspector");
        // highScore = PlayerPrefs.GetInt("HighScore", 0);
        playerScore = 0;
        UpdateScoreUI();
        UpdateHighScoreUI();
        Debug.Log($"LogicScript - Loaded HighScore = {highScore}");
        // highScoreText.text = playerScore.ToString();
    }

    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        UpdateScoreUI();
        CheckAndSaveHighScore();
    }
    

 void CheckAndSaveHighScore()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt(PREF_KEY, highScore);
            PlayerPrefs.Save();
            UpdateHighScoreUI();
            Debug.Log("Saved HighScore: " + highScore);
        }
    }

     void UpdateScoreUI()
    {
        if (scoreText != null) scoreText.text = playerScore.ToString();
    }

    void UpdateHighScoreUI()
    {
        if (highScoreText != null) highScoreText.text = "HighScore: " + highScore.ToString();
    }


    public void restartGame()
    {
        playerScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ObstacleMoveScript.moveSpeed = 9;
    }
    public void gameOver()
    {
        gameOverSound.Play();
        gameOverScreen.SetActive(true);   
    }
}
