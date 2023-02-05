using System.Collections;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] m_collectibles;
    
    [SerializeField]
    private float m_collectibleVMoveAmount = 1f;
    
    [SerializeField]
    private float m_collectibleHMoveAmount = 0.25f;
    
    [SerializeField]
    private float m_collectibleMoveSpeed = 3f;

    [SerializeField]
    private Transform m_playerPosition;

    private void Awake()
    {
        foreach (SpriteRenderer collectible in m_collectibles)
        {
            collectible.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        PlayerMovement playerMovement = _other.GetComponent<PlayerMovement>();
        if (playerMovement == null)
            return;
        
        playerMovement.SetPosition(m_playerPosition.position);
        GameManager.Instance.RunCompleted();
        StartCoroutine(ShowRewards());
    }
    
    private IEnumerator ShowRewards()
    {
        float timer = 0;
        while (timer < 2f) // 2 second delay
        {
            timer += Time.deltaTime;
            yield return null;
        }
        
        for (int i = 0; i < m_collectibles.Length; i++)
        {
            m_collectibles[i].enabled = GameManager.Instance.Collectibles[i];
        }
        
        timer = 0;
        while (timer < 1)
        {
            timer += Time.deltaTime * m_collectibleMoveSpeed;
            for (int i = 0; i < m_collectibles.Length; i++)
            {
                SpriteRenderer collectible = m_collectibles[i];
                float x = i switch
                {
                    0 => -m_collectibleHMoveAmount,
                    2 => m_collectibleHMoveAmount,
                    _ => 0
                };
                Vector2 targetPos = new (x, m_collectibleVMoveAmount);
                Vector2 pos = Vector2.Lerp(Vector2.zero, targetPos, timer);
                collectible.transform.localPosition = pos;
            }

            yield return null;
        }
    }
}
