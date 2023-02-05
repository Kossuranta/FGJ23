using UnityEngine;

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
    
    [SerializeField]
    private AudioClip m_playerSpeakNeutral;
    
    [SerializeField]
    private AudioClip m_playerSpeakHappy;

    private void Awake()
    {
        Instance = this;
        if (s_instance != this)
            return;
    }

    public void Stop()
    {
        m_audioSource.Stop();
    }

    public void PlayPlayer()
    {
        m_audioSource.clip = m_playerSpeak;
        m_audioSource.Play();
    }

    public void PlayDaddyAngy()
    {
        m_audioSource.clip = m_daddySpeakAngy;
        m_audioSource.Play();
    }
    
    public void PlayDaddyNeutral()
    {
        m_audioSource.clip = m_playerSpeakNeutral;
        m_audioSource.Play();
    }
    
    public void PlayDaddyHappy()
    {
        m_audioSource.clip = m_playerSpeakHappy;
        m_audioSource.Play();
    }
}
