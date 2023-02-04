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

    private void OnTriggerEnter2D(Collider2D _other)
    {
        PlayerMovement playerMovement = _other.GetComponent<PlayerMovement>();
        if (playerMovement == null)
            return;
        
        StartCoroutine(ShowRewards());
    }
    
    private IEnumerator ShowRewards()
    {
        float startHeight = m_collectibles[0].transform.localPosition.y;
        float endHeight = startHeight + m_collectibleVMoveAmount;
        float endOffsetX = m_collectibles[0].transform.localPosition.x + m_collectibleHMoveAmount;
        /*while (m_timer < 1)
        {
            m_timer += Time.deltaTime * m_collectibleMoveSpeed;
            Vector3 pos = m_collectible.localPosition;
            pos.x = Mathf.Lerp()
            pos.y = Mathf.Lerp(startHeight, endHeight, m_timer);
            m_collectible.localPosition = pos;
            yield return null;
        }*/
        yield return null;
    }
}
