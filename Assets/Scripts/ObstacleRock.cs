using UnityEngine;

public class ObstacleRock : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rockRigidbody;

    [SerializeField]
    private Collider2D m_trigger;

    private void Awake()
    {
        m_trigger.enabled = true;
        m_rockRigidbody.simulated = false;
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        PlayerMovement playerMovement = _other.GetComponent<PlayerMovement>();
        if (playerMovement == null)
            return;

        m_trigger.enabled = false;
        m_rockRigidbody.simulated = true;
    }
}
