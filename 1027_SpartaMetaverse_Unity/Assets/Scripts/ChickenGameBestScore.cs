using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;

public class ChickenGameBestScore : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;

    private int currentScore;
    
    void Start()
    {
        SetScoreUI();
    }

    public void SetScoreUI()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        BestScoreText.text = $"Best Score:\n{bestScore}";
    }
}
