using System;
using UnityEngine;

public class IdleAnimator : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer m_spriteRenderer;
    
    [SerializeField]
    private Sprite[] m_sprites;
    
    [SerializeField]
    private float m_animationDelay = 0.5f;
    
    private int m_animationIndex;
    private float m_timer;

    private void Awake()
    {
        if (m_spriteRenderer == null)
        {
            Debug.LogError("IdleAnimator is missing SpriteRenderer");
            enabled = false;
        }

        if (m_sprites.Length == 0)
        {
            Debug.LogError("IdleAnimator is missing Sprites");
            enabled = false;
        }
    }

    private void OnEnable()
    {
        m_spriteRenderer.sprite = m_sprites[0];
    }

    private void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer < m_animationDelay)
            return;
        
        m_timer = 0;

        m_animationIndex++;
        if (m_animationIndex >= m_sprites.Length)
            m_animationIndex = 0;
        m_spriteRenderer.sprite = m_sprites[m_animationIndex];
    }
}