using System;
using UnityEngine;

public abstract class BaseNode : MonoBehaviour
{
    [SerializeField]
    private Transform m_playerPosition;

    protected GameManager m_gameManager;
    protected Data m_data;

    private void Start()
    {
        m_gameManager = GameManager.Instance;
        m_data = m_gameManager.Data;
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