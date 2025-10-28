using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Play UI 닫기 및 게임 시작
public class PlayButton : MonoBehaviour
{
    public ChickenSceneManager ChickenSceneManager;

    public void OnClickStart()
    {
        ChickenSceneManager.HideMiniGame();
    }
}
