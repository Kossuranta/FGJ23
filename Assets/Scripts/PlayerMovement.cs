using UnityEngine;

public class PlayerMovement : MonoBehaviour
{      
    [SerializeField]
    private Rigidbody2D m_rigidbody;
    
    private float m_moveSpeed;
    private GameManager m_gameManager;

    public void Initialize()
    {
        m_gameManager = GameManager.Instance;
        m_moveSpeed = m_gameManager.Data.MoveSpeed;
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

    public void Jump(float _force)
    {
        
    }

    public void Sprint()
    {
        
    }
}
