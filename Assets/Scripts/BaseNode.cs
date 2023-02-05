using UnityEngine;

public abstract class BaseNode : MonoBehaviour
{
    [SerializeField]
    private Transform m_playerPosition;

    [SerializeField]
    private AudioClip m_clip;

    [SerializeField]
    private AudioSource m_audioSource;

    private void Start()
    {
        Initialize();
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        PlayerMovement playerMovement = _other.GetComponent<PlayerMovement>();
        if (playerMovement == null)
            return;

        playerMovement.SetPosition(m_playerPosition.position);
        Activate(playerMovement);
        m_audioSource.PlayOneShot(m_clip);
    }

    protected abstract void Initialize();
    protected abstract void Activate(PlayerMovement _playerMovement);
}