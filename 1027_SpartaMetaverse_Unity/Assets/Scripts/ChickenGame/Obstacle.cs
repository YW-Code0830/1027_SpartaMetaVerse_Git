using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = 1f;

    public float holeSizeMin = 1f;                  // 통과 공간 최소 최대 크기
    public float holeSizeMax = 3f;
    
    public Transform topObject;                     // 장애물 오브젝트의 위치값
    public Transform bottomObject;

    public float widthPadding = 4f;                 // 각 장애물 거리
    
    ChickenGame_GameManager gameManager;

    public void Start()
    {
        gameManager = ChickenGame_GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstaclCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;
        
        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ChickenGame_Player player = collision.GetComponent<ChickenGame_Player>();
        if (player != null)
        {
            gameManager.AddScore(1);
        }
    }
}
