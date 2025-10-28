using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public ChickenSceneManager chickenSceneManager;

    // 버튼 클릭 시 실행
    public void OnClickRestart()
    {
        // 씬 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
