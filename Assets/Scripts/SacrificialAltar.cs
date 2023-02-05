using System.Collections;
using UnityEngine;

public class SacrificialAltar : MonoBehaviour
{
    [SerializeField]
    private CollectibleType m_collectibleType;

    [SerializeField]
    private SpriteRenderer m_spriteRenderer;

    [SerializeField]
    private Transform m_collectible;

    [SerializeField]
    private float m_collectibleMoveAmount = 1f;
    
    [SerializeField]
    private float m_collectibleMoveSpeed = 3f;

    [SerializeField]
    private AudioSource m_audioSource;

    [SerializeField]
    private AudioClip m_clip; 

    private bool m_collected;
    private float m_timer;

    private void OnTriggerEnter2D(Collider2D _other)
    {   
         
        if (m_collected)
            return;
        
        PlayerMovement playerMovement = _other.GetComponent<PlayerMovement>();
        if (playerMovement == null)
            return;

        m_audioSource.PlayOneShot(m_clip);
        playerMovement.GameManager.Collectibles[(int)m_collectibleType] = true;
        m_spriteRenderer.sprite = playerMovement.GameManager.CollectibleSprites[(int)m_collectibleType];
        m_collected = true;

        StartCoroutine(ShowReward());
    }

    private IEnumerator ShowReward()
    {
        float startHeight = m_collectible.localPosition.y;
        float endHeight = startHeight + m_collectibleMoveAmount;
        while (m_timer < 1)
        {
            m_timer += Time.deltaTime * m_collectibleMoveSpeed;
            Vector3 pos = m_collectible.localPosition;
            pos.y = Mathf.Lerp(startHeight, endHeight, m_timer);
            m_collectible.localPosition = pos;
            yield return null;
        }
    }
}
