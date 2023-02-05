using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button m_btnStart;
    
    [SerializeField]
    private Button m_btnReset;

    [SerializeField]
    private Button m_btnNextLevel;

    [SerializeField]
    private Button m_btnRestart;

    [SerializeField]
    private GameObject m_levelCompletedButtons;

    [SerializeField]
    private SliderManager m_sliderManager;

    [SerializeField]
    private RectTransform m_sideSlider;

    [SerializeField]
    private int m_sideSliderHiddenPos;

    [SerializeField]
    private int m_sideSliderVisiblePos;

    [SerializeField]
    private float m_sideSliderAnimSpeed = 3f;

    private GameManager m_gameManager;
    private bool m_showSideSlider = true;
    private float m_timer;

    public void Initialize(GameManager _gameManager)
    {
        m_gameManager = _gameManager;
        m_sliderManager.Initialize(_gameManager);
        
        m_btnStart.onClick.AddListener(RunStart);
        m_btnReset.onClick.AddListener(RunReset);
        m_btnRestart.onClick.AddListener(RunReset);
        m_btnNextLevel.onClick.AddListener(NextLevel);
        
        UpdateButtonStates();

        m_gameManager.a_runStart += UpdateButtonStates;
        m_gameManager.a_runStart += HideSideSlider;
        m_gameManager.a_runReset += UpdateButtonStates;
        m_gameManager.a_runReset += ShowSideSlider;
        
        m_levelCompletedButtons.SetActive(false);
        
        Vector2 pos = m_sideSlider.anchoredPosition;
        pos.x = m_sideSliderHiddenPos;
        m_sideSlider.anchoredPosition = pos;
    }

    private void Update()
    {
        if (m_showSideSlider)
        {
            if (m_timer >= 1f)
                return;

            m_timer += Time.deltaTime * m_sideSliderAnimSpeed;
        }
        else
        {
            if (m_timer <= 0f)
                return;
            
            m_timer -= Time.deltaTime * m_sideSliderAnimSpeed;
        }
        
        Vector2 pos = m_sideSlider.anchoredPosition;
        pos.x = Mathf.Lerp(m_sideSliderHiddenPos, m_sideSliderVisiblePos, m_timer);
        m_sideSlider.anchoredPosition = pos;
    }

    public void ShowLevelCompletedButtons()
    {
        m_levelCompletedButtons.SetActive(true);
    }
    
    private void RunStart()
    {
        m_gameManager.RunStart();
    }

    private void RunReset()
    {
        m_levelCompletedButtons.SetActive(false);
        m_gameManager.RunReset();
    }

    private void NextLevel()
    {
        m_levelCompletedButtons.SetActive(false);
        m_gameManager.NextLevel();
    }

    private void UpdateButtonStates()
    {
        m_btnStart.gameObject.SetActive(!m_gameManager.IsRunning);
        m_btnReset.gameObject.SetActive(m_gameManager.IsRunning);
    }

    private void HideSideSlider()
    {
        m_showSideSlider = false;
    }

    private void ShowSideSlider()
    {
        m_showSideSlider = true;
    }

    public void ToggleSideSlider()
    {
        m_showSideSlider = !m_showSideSlider;
    }
}
