using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 치킨 게임 씬 시작 UI 관리
public class ChickenSceneManager : MonoBehaviour
{
    public GameObject miniGamePanel;   // 미니게임 UI 전체 패널
    public ChickenGame_GameManager gameManager;

    private bool isPaused = true;

    // 미니게임 내부 플레이 창 띄우기
    public void ShowMiniGame()
    {
        miniGamePanel.SetActive(true);
        Time.timeScale = 0f;
        gameManager.ChickenGamePlayer.PausePlayer(true);
    }

    // 미니게임 내부 플레이 창 닫기
    public void HideMiniGame()
    {
        miniGamePanel.SetActive(false);
        Time.timeScale = 1f;
        gameManager.ChickenGamePlayer.PausePlayer(false);
    }
}
