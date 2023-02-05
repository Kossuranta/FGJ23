using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    private static AudioManager s_instance;
    
    public static AudioManager Instance // Illegal singleton
    {
        get => s_instance;
        private set
        {
            if (s_instance != null)
            {
                Debug.LogError("Multiple instances of AudioManager!");
                DestroyImmediate(value.gameObject);
                return;
            }

            s_instance = value;
        }
    }
    
    [SerializeField]
    private AudioSource m_audioSource;
    
    [SerializeField]
    private AudioClip m_playerSpeak;
    
    [SerializeField]
    private AudioClip m_daddySpeakAngy;
    
    [FormerlySerializedAs("m_playerSpeakNeutral"),SerializeField]
    private AudioClip m_daddySpeakNeutral;
    
    [FormerlySerializedAs("m_playerSpeakHappy"),SerializeField]
    private AudioClip m_daddySpeakHappy;

    [SerializeField]
    private AudioClip m_daddySlap;

    [SerializeField]
    private AudioClip m_playerDied;

    [SerializeField]
    private AudioClip m_playerDash;

    private void Awake()
    {
        Instance = this;
        if (s_instance != this)
            return;
    }

    public void PlayPlayer()
    {
        m_audioSource.clip = m_playerSpeak;
        m_audioSource.Play();
    }

    public void PlayDaddyAngy()
    {
        m_audioSource.PlayOneShot(m_daddySpeakAngy);
    }
    
    public void PlayDaddyNeutral()
    {
        m_audioSource.PlayOneShot(m_daddySpeakNeutral);
    }
    
    public void PlayDaddyHappy()
    {
        m_audioSource.PlayOneShot(m_daddySpeakHappy);
    }

    public void PlayDaddySlap()
    {
        m_audioSource.PlayOneShot(m_daddySlap);
    }

    public void PlayPlayerDead()
    {
        m_audioSource.PlayOneShot(m_playerDied);
    }

    public void PlayPlayerDash()
    {
        m_audioSource.PlayOneShot(m_playerDash);
    }
}
