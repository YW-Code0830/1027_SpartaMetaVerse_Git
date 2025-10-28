using UnityEngine;
using UnityEngine.SceneManagement;

// 메인씬 일시정지, 해제
// Additive 로드
public class MainSceneManager : MonoBehaviour
{
    private string miniGameSceneName = "ChickenGame";
    // private string mainSceneName = "MainScene";
    // private bool isMiniGameActive = false;

    // private ChickenGameTrigger chickenGameTrigger;
    private Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        RestorePlayerPosition();
    }

    public void LoadMiniGame()
    {
        SceneManager.LoadScene(miniGameSceneName);
    }

    private void RestorePlayerPosition()
    {
        if (GameManager.Instance != null && GameManager.Instance.SavedPlayerPosition.HasValue)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();

            if (player != null)
            {
                player.transform.position = GameManager.Instance.SavedPlayerPosition.Value;
                Debug.Log($"플레이어 위치 복원: {GameManager.Instance.SavedPlayerPosition.Value}");

                // 위치 복원 후 초기화
                GameManager.Instance.SavedPlayerPosition = null;
            }
        }
    }
}  