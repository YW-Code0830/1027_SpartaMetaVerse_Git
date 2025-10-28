using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    
    
    [SerializeField] private SpriteRenderer characterRenderer;
    
    // 이동 방향 지정
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }
    
    // 바라보는 방향 지정
    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }
    
    protected AnimationController animationController;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        // 캐릭터 구르는 이슈 방지
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        animationController = GetComponent<AnimationController>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        HandleAction();
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    protected virtual Vector2 HandleAction()
    {
        return movementDirection;
    }

    // 이동 속도와 방향을 실제 물리로 적용
    private void Movement(Vector2 direction)
    {
        direction = direction * 5;
        
        // 이동에 대한 처리
        _rigidbody.velocity = direction;
        animationController.Move(direction);
    }
    
}
