using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 트리거 감지 후 진입 전 팝업 띄우기
public class ChikenGameTrigger : MonoBehaviour
{
    public GameObject popupUI;
    
    private bool isPlayerInRange = false;

    public static Vector3? PlayerData = Vector3.zero;
    
    // 팝업 UI는 false로 둔다
    private void Start()
    {
        popupUI.SetActive(false);
    }
    
    // Player가 접근 시 팝업 UI를 띄우고 MainScene을 멈춘다
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SavedPlayerPosition = other.transform.position;
            Debug.Log($"플레이어 위치 저장: {other.transform.position}");
            
            popupUI.SetActive(true); 
            isPlayerInRange = true;
            Time.timeScale = 0;
        }
    }

}
