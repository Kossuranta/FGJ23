using UnityEngine;

public class PlayerMovement : MonoBehaviour
{      
    [SerializeField]
    private Rigidbody2D m_rigidbody;

    private GameManager m_gameManager;
    private float m_moveSpeed;
    private float m_jumpForce;
    private float m_sprintDuration;
    private int m_sprintSpeedMultiplier;

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
            return;
        
        m_rigidbody.MovePosition((Vector2)transform.position + Vector2.right * (Time.deltaTime * m_moveSpeed));
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
        
    }
}
