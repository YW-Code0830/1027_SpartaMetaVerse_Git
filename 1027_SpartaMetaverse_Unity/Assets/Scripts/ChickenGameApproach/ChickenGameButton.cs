using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 메인씬 > 치킨게임 씬 진입
public class ChickenGameButton : MonoBehaviour
{
    public GameObject popupUI;
    
    [SerializeField] private MainSceneManager mainSceneManager;
    
    // public Vector3 PlayerPosition;
    // private Player player;
    
    public void OpenMiniGame()
    {
        popupUI.SetActive(false);
        mainSceneManager.LoadMiniGame();
    }
}
