using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class ChickenGame_Player : MonoBehaviour
{
    Animator animator;
    private Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    private float deathCooldown = 0f;

    private bool isFlap = false;

    public bool godMode = false;
    
    ChickenGame_GameManager gameManager;
    ChickenGame_UIManager uiManager;

    void Awake()
    {
        gameManager = ChickenGame_GameManager.Instance;
        uiManager = FindObjectOfType<ChickenGame_UIManager>();
        // GetComponentInChildren: 하위의 오브젝트의 것을 포함하여 가져오게끔 한다
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        if(animator == null)
            Debug.LogError("Not Found Animator");
        
        if(_rigidbody == null)
            Debug.LogError("Not Found Rigidbody");
    }
    
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                
            }
            else
            {
                deathCooldown -= Time.deltaTime;
                // 이전 프레임과 현재 프레임 사이의 시간, Update()에서만 사용할 수 있다
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    // FixedUpdate: 물리처리를 하는 함수
    private void FixedUpdate()
    {
        if (Time.timeScale == 0 || isDead) return;
        
        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }
        
        _rigidbody.velocity = velocity;
        
        float angle = Mathf.Clamp(_rigidbody.velocity.y * 10, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        
        if (isDead) return;
        
        isDead = true;
        deathCooldown = 1f;
        
        animator.SetInteger("IsDie", 1);
        
        // 죽은 후 rigidbody 멈춤
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0f;
        _rigidbody.simulated = false;
        
        gameManager.GameOver();
    }
    
    public void PausePlayer(bool pause)
    {
        animator.speed = pause ? 0f : 1f;

        if (pause)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.angularVelocity = 0f; // 회전까지 멈춤
            _rigidbody.simulated = false;
            _rigidbody.gravityScale = 0f;
        }
        else
        {
            _rigidbody.simulated = true;
            _rigidbody.gravityScale = 1f;
        }
    }
}
