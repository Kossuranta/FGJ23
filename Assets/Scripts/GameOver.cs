using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Button m_btnQuitGame;

    [SerializeField]
    private Button m_btnRestart;
    
    private void Awake()
    {
        m_btnQuitGame.onClick.AddListener(QuitGame);
        m_btnRestart.onClick.AddListener(RestartGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
