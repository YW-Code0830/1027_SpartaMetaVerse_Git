using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 진입 UI에서 뒤로가기
public class RefuseButton : MonoBehaviour
{
    public GameObject uiToClose;

    public void Close()
    {
        uiToClose.SetActive(false);
        Time.timeScale = 1f;
    }
}
