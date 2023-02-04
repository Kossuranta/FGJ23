using UnityEngine;

public class PlayerMovement : MonoBehaviour
{      
    [SerializeField]
    private Rigidbody2D m_rigidbody;

    private GameManager m_gameManager;
    private float m_moveSpeed;
    private float m_jumpForce;
    private float m_sprintDuration;
    private float m_sprintSpeedMultiplier;

    private bool m_isSprinting;
    private float m_sprintTimer;

    public void Initialize(GameManager _gameManager)
    {
        m_gameManager = _gameManager;
        
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

    public void SetPosition(Vector3 _pos)
    {
        transform.position = _pos;
    }

    public void Jump()
    {
        // TODO: Implement gravity and vertical movement first to movement        
    }

    public void Sprint()
    {
        m_isSprinting = true;
        m_moveSpeed *= m_sprintSpeedMultiplier;
        m_sprintTimer = m_sprintDuration;
    } 
}
