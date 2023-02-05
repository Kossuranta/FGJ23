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

    private void Awake()
    {
        Instance = this;
        if (s_instance != this)
            return;
    }

    public void Stop()
    {
        //m_audioSource.Stop();
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
        m_audioSource.clip = m_daddySpeakHappy;
        m_audioSource.Play();
    }

    public void PlayDaddySlap()
    {
        m_audioSource.PlayOneShot(m_daddySlap);
    }
}
