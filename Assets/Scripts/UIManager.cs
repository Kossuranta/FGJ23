using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button m_btnStart;
    
    [SerializeField]
    private Button m_btnReset;

    [SerializeField]
    private SliderManager m_sliderManager;

    private GameManager m_gameManager;
    
    public void Initialize(GameManager _gameManager)
    {
        m_gameManager = _gameManager;
        m_sliderManager.Initialize(_gameManager);
        
        m_btnStart.onClick.AddListener(RunStart);
        m_btnReset.onClick.AddListener(RunReset);
        
        UpdateButtonStates();

        m_gameManager.a_runStart += UpdateButtonStates;
        m_gameManager.a_runReset += UpdateButtonStates;
    }
    
    private void RunStart()
    {
        m_gameManager.RunStart();
    }

    private void RunReset()
    {
        m_gameManager.RunReset();
    }

    private void UpdateButtonStates()
    {
        m_btnStart.gameObject.SetActive(!m_gameManager.IsRunning);
        m_btnReset.gameObject.SetActive(m_gameManager.IsRunning);
    }
}
