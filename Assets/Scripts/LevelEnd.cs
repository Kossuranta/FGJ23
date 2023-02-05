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

    [SerializeField]
    private GameObject m_speechBubble;
    
    [SerializeField]
    private GameObject[] m_missingObjects;

    [SerializeField]
    private Animator m_daddySpeechAnimator;

    [SerializeField]
    private IdleAnimator m_daddyHappy;

    [SerializeField]
    private IdleAnimator m_daddyWalk;

    [SerializeField]
    private Sprite[] m_daddyAngy;

    [SerializeField]
    private Transform m_daddy;

    [SerializeField]
    private Sprite m_daddyHappyFirstSprite;

    [SerializeField]
    private SpriteRenderer m_daddySpriteRenderer;

    private void Awake()
    {
        foreach (SpriteRenderer collectible in m_collectibles)
        {
            collectible.enabled = false;
        }
        
        m_speechBubble.SetActive(false);
        m_daddySpeechAnimator.enabled = false;
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
        yield return new WaitForSeconds(1f);

        int missingCount = 0;
        bool[] collected = GameManager.Instance.Collectibles;
        for (int i = 0; i < m_collectibles.Length; i++)
        {
            bool hasCollectible = collected[i];
            if (!hasCollectible)
                missingCount++;
            m_collectibles[i].enabled = hasCollectible;
            m_missingObjects[i].SetActive(false);
        }
        
        float timer = 0;
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
        
        yield return new WaitForSeconds(1f);
        if (missingCount > 0)
        {
            m_speechBubble.SetActive(true);
            m_daddySpeechAnimator.enabled = true;
            for (int i = 0; i < collected.Length; i++)
            {
                if (collected[i])
                    continue;
                
                yield return new WaitForSeconds(0.5f);
                m_missingObjects[i].SetActive(true);
            }
            
            yield return new WaitForSeconds(2f);
            m_speechBubble.SetActive(false);
            m_daddySpeechAnimator.enabled = false;
            yield return new WaitForSeconds(0.5f);
        }

        switch (missingCount)
        {
            case 0:
                StartCoroutine(DaddyHappy());
                break;
            
            case 1:
            case 2:
                StartCoroutine(DaddyWalkAway());
                break;
            
            case 3:
            default:
                StartCoroutine(DaddyAngy());
                break;
        }
    }
    
    private IEnumerator DaddyHappy()
    {
        GameManager.Instance.Player.DaddyHappyHidePlayer();
        m_daddySpriteRenderer.sprite = m_daddyHappyFirstSprite;
        yield return new WaitForSeconds(0.5f);
        m_daddyHappy.enabled = true;
        yield return new WaitForSeconds(2f);
        
        GameManager.Instance.EndAnimationCompleted();
    }
    
    private IEnumerator DaddyAngy()
    {
        m_daddyWalk.enabled = true;
        m_daddySpriteRenderer.flipX = true;
        float xStartPos = m_daddy.localPosition.x;
        float timer = 0;
        while (timer < 1f)
        {
            timer += Time.deltaTime / 2f;
            Vector3 pos = m_daddy.localPosition;
            pos.x = Mathf.Lerp(xStartPos, m_playerPosition.localPosition.x, timer);
            m_daddy.localPosition = pos;
            yield return null;
        }

        m_daddyWalk.enabled = false;
        foreach (Sprite sprite in m_daddyAngy)
        {
            m_daddySpriteRenderer.sprite = sprite;
            yield return new WaitForSeconds(0.5f);
        }
        
        GameManager.Instance.Player.DaddySlapFly();
        yield return new WaitForSeconds(1f);
        
        m_daddyWalk.enabled = true;
        m_daddySpriteRenderer.flipX = false;
        while (timer < 2f)
        {
            timer += Time.deltaTime;
            m_daddy.Translate(Vector3.right * (Time.deltaTime * 3f));
            yield return null;
        }
        
        GameManager.Instance.EndAnimationCompleted();
        
        while (timer < 10f)
        {
            timer += Time.deltaTime;
            m_daddy.Translate(Vector3.right * (Time.deltaTime * 3f));
            yield return null;
        }
    }

    private IEnumerator DaddyWalkAway()
    {
        m_daddyWalk.enabled = true;
        float timer = 0;
        while (timer < 2f)
        {
            timer += Time.deltaTime;
            m_daddy.Translate(Vector3.right * (Time.deltaTime * 3f));
            yield return null;
        }
        
        GameManager.Instance.EndAnimationCompleted();
        
        while (timer < 10f)
        {
            timer += Time.deltaTime;
            m_daddy.Translate(Vector3.right * (Time.deltaTime * 3f));
            yield return null;
        }
    }
}
