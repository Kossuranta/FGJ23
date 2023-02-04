using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button m_btnStart;
    
    [SerializeField]
    private Button m_btnReset;
    
    private GameManager m_gameManager;
    
    public void Initialize(GameManager _gameManager)
    {
        m_gameManager = _gameManager;
        
        m_btnStart.onClick.AddListener(RunStart);
        m_btnReset.onClick.AddListener(RunReset);
        
        UpdateButtonStates();
    }
    
    private void RunStart()
    {
        m_gameManager.RunStart();
        UpdateButtonStates();
    }

    private void RunReset()
    {
        m_gameManager.RunReset();
        UpdateButtonStates();
    }

    private void UpdateButtonStates()
    {
        m_btnStart.gameObject.SetActive(!m_gameManager.IsRunning);
        m_btnReset.gameObject.SetActive(m_gameManager.IsRunning);
    }
}
