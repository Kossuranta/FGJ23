using UnityEngine;

public abstract class BaseNode : MonoBehaviour
{
    [SerializeField]
    private Transform m_playerPosition;

    private void Start()
    {
        Initialize();
    }

    private void OnTriggerEnter(Collider _other)
    {
        PlayerMovement playerMovement = _other.GetComponent<PlayerMovement>();

        if (playerMovement == null)
        {
            Debug.LogError("OnTriggerEnter called, but other collider doesn't have PlayerMovement component!");
            return;
        }
        
        playerMovement.SetPosition(m_playerPosition.position);
        Activate(playerMovement);
    }

    protected abstract void Initialize();
    protected abstract void Activate(PlayerMovement _playerMovement);
}