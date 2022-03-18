using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
     
    private void Start()
    {    
        int highScore = PlayerPrefs.GetInt(UIManager.highScoreKey, 0);
        highScoreText.text = "High Score : " + highScore.ToString();             
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
