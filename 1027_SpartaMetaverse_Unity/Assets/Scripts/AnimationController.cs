using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private static readonly int PosX = Animator.StringToHash("PosX");
    private static readonly int PosY = Animator.StringToHash("PosY");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private Vector2 lastDirection = Vector2.down;
    
    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // PlayerDirection에 따라 애니메이션을 재생하는 메서드
    public void Move(Vector2 moveVector)
    {
        bool isMoving = moveVector.magnitude > 0.1f;
        animator.SetBool(IsMoving, isMoving);

        if (isMoving)
        {
            lastDirection = ClampDirection(moveVector.normalized);
        }
        
        animator.SetFloat(PosX, lastDirection.x);
        animator.SetFloat(PosY, lastDirection.y);
    }
    
    // lastDirection에 4가지 방향 이외의 방향이 저장되어 보간 시 캐릭터가 구르는 문제 보완
    private Vector2 ClampDirection(Vector2 moveVector)
    {
        if (Mathf.Abs(moveVector.x) > Mathf.Abs(moveVector.y))
        {
            if(moveVector.x > 0)
                return new Vector2(1, 0);
            else
                return new Vector2(-1, 0);
        }
        else
        {
            if(moveVector.y > 0)
                return new Vector2(0, 1);
            else
                return new Vector2(0, -1);
        }
    }
}