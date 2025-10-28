using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 미니 게임에서 마을 씬으로 복귀
public class BackToVillageButton : MonoBehaviour
{
    private MainSceneManager mainSceneManager;
    string mainSceneName = "MainScene";

    void Awake()
    {
        mainSceneManager = FindObjectOfType<MainSceneManager>();
    }
    
    public void BackToVillage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainSceneName);
        // mainSceneManager.PlayerPosition();
    }
}
