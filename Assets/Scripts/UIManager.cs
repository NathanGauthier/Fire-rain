using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public int playerLives = 3;
    public int score = 0;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public const string highScoreKey = "HighScore";

    private void Start()
    {
        instance = this;

        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void Update()
    {   
        if(playerLives == 0)
        {
            GoBackToMenu();
        }
    }

    public void TakeLife()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
    }

    public void AddScore()
    {
        score += 100;
        scoreText.text = score.ToString();
    }
    private void OnDestroy()
    {
        int currentHighScore = PlayerPrefs.GetInt(highScoreKey, 0);
        if (score >= currentHighScore)
        {
            PlayerPrefs.SetInt(highScoreKey,score);
        }
    }

    void GoBackToMenu()
    {     
        SceneManager.LoadScene(0);     
    }
}
