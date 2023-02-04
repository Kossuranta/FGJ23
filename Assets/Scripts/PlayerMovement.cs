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

    private GameManager m_gameManager;
    private float m_moveSpeed;
    private float m_jumpForce;
    private float m_sprintDuration;
    private float m_sprintSpeedMultiplier;

    private bool  m_isSprinting;
    private float m_sprintTimer;

    public MoveState CurrentState { get; private set; }

    public void Initialize(GameManager _gameManager)
    {
        m_gameManager = _gameManager;
        CurrentState = MoveState.Idle;
        
        m_animator.Initilize(this);
        
        ResetValues();
    }

    public void ResetValues()
    {
        m_moveSpeed = m_gameManager.Data.MoveSpeed;
        m_jumpForce = m_gameManager.Data.JumpForce;
        m_sprintDuration = m_gameManager.Data.SprintDuration;
        m_sprintSpeedMultiplier = m_gameManager.Data.SprintSpeedMultiplier;
    }

    private void FixedUpdate()
    {
        if (!m_gameManager.IsRunning)
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
                m_moveSpeed = m_gameManager.Data.MoveSpeed;
                m_isSprinting = false;
            }
        }
    }

    private void LateUpdate()
    {
        if (!m_gameManager.IsRunning)
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
