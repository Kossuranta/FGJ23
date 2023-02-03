using UnityEngine;

public class JumpNode : MonoBehaviour
{
    [SerializeField]
    private Transform m_jumpPosition;
    
    private GameManager m_gameManager;
    private float m_jumpForce;

    private void Start()
    {
        m_gameManager = GameManager.s_gameManager;
        m_jumpForce = m_gameManager.Data.JumpForce;
    }

    private void OnTriggerEnter(Collider _other)
    {
        PlayerMovement playerMovement = _other.GetComponent<PlayerMovement>();
        playerMovement.SetPosition(m_jumpPosition.position);
        playerMovement.Jump(m_jumpForce);
    }
}
