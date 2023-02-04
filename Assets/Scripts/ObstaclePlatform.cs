using UnityEngine;

public class ObstaclePlatform : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 5f;

    [SerializeField]
    private Rigidbody2D m_rigidbody;

    [SerializeField]
    private Transform m_targetPosition;

    private bool m_isMoving;
    private float m_timer;
    private Vector2 m_startPosition;
    private Vector2 m_endPosition;
    private Vector2 m_position;

    private void Awake()
    {
        m_startPosition = transform.position;
        m_endPosition = m_targetPosition.position;
    }

    private void FixedUpdate()
    {
        if (!m_isMoving)
            return;

        m_timer += m_moveSpeed * Time.fixedDeltaTime;
        m_position = Vector2.Lerp(m_startPosition, m_endPosition, m_timer);
        m_rigidbody.MovePosition(m_position);

        if (m_timer >= 1)
            m_isMoving = false;
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        PlayerMovement playerMovement = _other.GetComponent<PlayerMovement>();
        if (playerMovement == null)
            return;
        
        m_isMoving = true;
    }
}
