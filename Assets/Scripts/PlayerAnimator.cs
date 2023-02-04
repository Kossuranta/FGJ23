using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer m_playerImage;

    [SerializeField]
    private float m_animationDelay;
    
    [SerializeField]
    private Sprite[] m_idleSprites;
    
    [SerializeField]
    private Sprite[] m_moveSprites;

    [SerializeField]
    private Sprite[] m_sprintSprites;

    [SerializeField]
    private Sprite[] m_jumpUpSprites;

    [SerializeField]
    private Sprite[] m_jumpDownSprites;

    [SerializeField]
    private Sprite[] m_deathSprites;

    private PlayerMovement m_player;
    private MoveState m_currentState;
    private Sprite[] m_currentAnimation;
    private int m_animationIndex;
    private float m_timer;

    public void Initilize(PlayerMovement _player)
    {
        m_player = _player;
        ChangeAnimation();
    }

    public void UpdateAnimator()
    {
        if (m_currentState != m_player.CurrentState)
        {
            ChangeAnimation();
            m_animationIndex = 0;
            m_playerImage.sprite = m_currentAnimation[m_animationIndex];
            m_timer = 0;
            return;
        }
        
        m_timer += Time.deltaTime;
        if (m_timer < m_animationDelay)
            return;
        
        m_timer = 0;

        if (m_animationIndex >= m_currentAnimation.Length)
            m_animationIndex = 0;
        m_playerImage.sprite = m_currentAnimation[m_animationIndex];
        m_animationIndex++;
    }

    private void ChangeAnimation()
    {
        m_currentState = m_player.CurrentState;
        switch (m_currentState)
        {
            case MoveState.Idle:
                m_currentAnimation = m_idleSprites;
                break;
            
            case MoveState.Move:
                m_currentAnimation = m_moveSprites;
                break;
            
            case MoveState.Sprint:
                m_currentAnimation = m_sprintSprites;
                break;
            
            case MoveState.JumpUp:
                m_currentAnimation = m_jumpUpSprites;
                break;
            
            case MoveState.JumpDown:
                m_currentAnimation = m_jumpDownSprites;
                break;
            
            case MoveState.Death:
                m_currentAnimation = m_deathSprites;
                break;
        }
    }
}