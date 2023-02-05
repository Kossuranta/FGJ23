using UnityEngine;

public enum MoveState
{
    Idle,
    Move,
    Sprint,
    JumpUp,
    JumpDown,
    Death,
}

public class PlayerMovement : MonoBehaviour
{      
    [SerializeField]
    private Rigidbody2D m_rigidbody;

    [SerializeField]
    private PlayerAnimator m_animator;

    [SerializeField]
    private Collider2D m_collider;

    public GameManager GameManager { get; private set; }
    private float m_moveSpeed;
    private float m_jumpForce;
    private float m_sprintDuration;
    private float m_sprintSpeedMultiplier;

    private bool  m_isSprinting;
    private float m_sprintTimer;
    private bool m_isDead;

    public MoveState CurrentState { get; private set; }

    public void Initialize(GameManager _gameManager)
    {
        GameManager = _gameManager;
        CurrentState = MoveState.Idle;
        
        m_animator.Initilize(this);
        
        ResetValues();
    }

    public void ResetValues()
    {
        GameManager.Camera.IsFollowing = true;
        m_isDead = false;
        m_isSprinting = false;
        m_collider.enabled = true;
        m_moveSpeed = GameManager.Data.MoveSpeed;
        m_jumpForce = GameManager.Data.JumpForce;
        m_sprintDuration = GameManager.Data.SprintDuration;
        m_sprintSpeedMultiplier = GameManager.Data.SprintSpeedMultiplier;
    }

    private void FixedUpdate()
    {
        if (m_isDead)
            return;

        if (!GameManager.IsRunning)
        {
            m_rigidbody.velocity = Vector2.zero;
            return;
        }

        m_rigidbody.velocity = new Vector2(m_moveSpeed, m_rigidbody.velocity.y);

        if (m_isSprinting)
        {
            m_sprintTimer -= Time.fixedDeltaTime;
            if (m_sprintTimer <= 0)
            {
                m_moveSpeed = GameManager.Data.MoveSpeed;
                m_isSprinting = false;
            }
        }
    }

    private void LateUpdate()
    {
        if (m_isDead)
            CurrentState = MoveState.Death;
        else if (!GameManager.IsRunning)
            CurrentState = MoveState.Idle;
        else if (m_rigidbody.velocity.y > 1f)
            CurrentState = MoveState.JumpUp;
        else if (m_rigidbody.velocity.y < -1f)
            CurrentState = MoveState.JumpDown;
        else if (m_isSprinting)
            CurrentState = MoveState.Sprint;
        else
            CurrentState = MoveState.Move;
        
        m_animator.UpdateAnimator();
    }

    public void Die()
    {
        if (m_isDead)
            return;
        
        m_isDead = true;
        m_collider.enabled = false;
        m_rigidbody.velocity = new Vector2(0, 3f);
        GameManager.Camera.IsFollowing = false;
        Invoke(nameof(RunReset), 2.5f);
    }

    public void RunReset()
    {
        GameManager.RunReset();
    }

    public void SetPosition(Vector3 _pos)
    {
        transform.position = _pos;
    }

    public void Jump()
    {
        m_rigidbody.velocity = new Vector2(m_moveSpeed, m_jumpForce);
    }

    public void Sprint()
    {
        m_isSprinting = true;
        m_moveSpeed *= m_sprintSpeedMultiplier;
        m_sprintTimer = m_sprintDuration;
    } 
}
