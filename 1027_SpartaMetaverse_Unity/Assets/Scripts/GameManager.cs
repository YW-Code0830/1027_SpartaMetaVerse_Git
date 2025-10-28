using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static GameManager Instance { get; private set; }
    
    // 플레이어 위치 저장
    public Vector3? SavedPlayerPosition { get; set; }
    
    private void Awake()
    {
        // 싱글톤 패턴: 이미 인스턴스가 있으면 자신을 파괴
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 파괴되지 않음
            Debug.Log("GameManager 생성됨");
        }
        else
        {
            Destroy(gameObject); // 중복 인스턴스 제거
            Debug.Log("GameManager 중복 제거됨");
        }
    }
}