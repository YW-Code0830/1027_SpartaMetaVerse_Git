using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenGame_GameManager : MonoBehaviour
{
    static ChickenGame_GameManager gameManager;
    public static ChickenGame_GameManager Instance { get { return gameManager; } }

    private int bestScore = 0;
    public int BestScore { get { return bestScore; } }
    private const string BestScoreKey = "BestScore";
    
    private int currentScore = 0;
    
    ChickenGame_UIManager uiManager;
    public ChickenGame_UIManager UIManager { get { return uiManager; } }
    
    ChickenSceneManager chickenSceneManager;
    public ChickenSceneManager ChickenSceneManager { get { return chickenSceneManager; } }

    ChickenGame_Player chickenGamePlayer;
    public ChickenGame_Player ChickenGamePlayer { get { return chickenGamePlayer; } }
    
    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<ChickenGame_UIManager>();
        chickenSceneManager = FindObjectOfType<ChickenSceneManager>();
        chickenGamePlayer = FindObjectOfType<ChickenGame_Player>();
        
        // CameraOnOff(false);
    }

    public void Start()
    {
        chickenSceneManager.ShowMiniGame();
        uiManager.UpdateScore(0);
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.CurrentScore();
        uiManager.SetScoreUI();
        uiManager.ShowButton();
    }

    public void AddScore(int score)
    {
        if (ChickenGamePlayer.isDead) return;
        
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
        
        UpdateScore();
    }
    
    // 최고 점수 저장 코드
    void UpdateScore()
    {
        if (bestScore < currentScore)
        {
            Debug.Log("최고 점수 갱신");
            bestScore = currentScore;
            
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
            uiManager.SetScoreUI();
        }
    }

    // public void CameraOnOff(bool isOn)
    // {
    //     Camera mainCamera = Camera.main;
    //     if (mainCamera != null)
    //         mainCamera.enabled = isOn;
    // }
}
