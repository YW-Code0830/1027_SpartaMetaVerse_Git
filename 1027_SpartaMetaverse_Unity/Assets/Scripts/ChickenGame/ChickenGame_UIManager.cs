using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// 치킨 게임 내부 점수 UI
public class ChickenGame_UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    public TextMeshProUGUI BestScoreText;
    public TextMeshProUGUI CurrentScoreText;
    
    // public GameObject RestartButton;
    // public GameObject BackToVillageButton;

    public GameObject GameOverPanel;

    private int currentScore;
    
    void Start()
    {
        GameOverPanel.SetActive(false);
    }

    public void ShowButton()
    {
        GameOverPanel.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
        currentScore = score;
    }

    public void CurrentScore()
    {
        CurrentScoreText.text = "Current Score:" + currentScore.ToString();
    }

    public void SetScoreUI()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        BestScoreText.text = $"Best Score: {bestScore}";
    }
}
