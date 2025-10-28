using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseController
{
    private Camera camera;
    private int lastDirection;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override Vector2 HandleAction()
    {
        // Axis 축 값을 이용해 키 입력을 받음
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // 방향 벡터
        movementDirection = new Vector2(horizontal, vertical).normalized;
        
        return movementDirection;
    }
}