using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum CollectibleType
{
    Heart = 0,
    Brain = 1,
    Chicken = 2,
}

public class GameManager : MonoBehaviour
{
    private static GameManager s_instance;
    
    public static GameManager Instance // Illegal singleton
    {
        get => s_instance;
        private set
        {
            if (s_instance != null)
            {
                Debug.LogError("Multiple instances of GameManager!");
                DestroyImmediate(value.gameObject);
                return;
            }

            s_instance = value;
        }
    }

    [SerializeField]
    private float m_deathHeight;

    [SerializeField]
    private EventSystem m_eventSystemPrefab;

    [SerializeField]
    private PlayerMovement m_playerPrefab;
    
    [SerializeField]
    private CameraController m_cameraPrefab;

    [SerializeField]
    private UIManager m_uiManagerPrefab;
    
    [SerializeField]
    private Sprite[] m_collectibleSprites;

    public SpawnPoint SpawnPoint { get; private set; }
    public Data Data { get; private set; }
    public PlayerMovement Player { get; private set; }
    public CameraController Camera { get; private set; }
    public UIManager UIManager { get; private set; }
    public Sprite[] CollectibleSprites => m_collectibleSprites;

    public bool IsRunning { get; private set; }
    public bool[] Collectibles { get; } = new bool[3];

    public Action a_runStart;
    public Action a_runReset;

    private void Awake()
    {
        Instance = this;
        if (s_instance != this)
            return;

        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        if (eventSystem == null)
            Instantiate(m_eventSystemPrefab);

        SpawnPoint = FindObjectOfType<SpawnPoint>();
        if (SpawnPoint == null)
            Debug.LogError("Scene is missing SpawnPoint!");

        Data = new Data
        {
            MoveSpeed = PlayerPrefs.GetFloat("MoveSpeed", 0f),
            SprintDuration = PlayerPrefs.GetFloat("SprintDuration", 0f),
            SprintSpeedMultiplier = PlayerPrefs.GetInt("SprintSpeedMultiplier", 0),
            JumpForce = PlayerPrefs.GetFloat("JumpForce", 0f),
            Gravity = PlayerPrefs.GetFloat("Gravity", 0f)
        };
    }

    private void Start()
    {
        Camera = Instantiate(m_cameraPrefab);
        Player = Instantiate(m_playerPrefab);
        Camera.Initialize(Player);
        Player.Initialize(this);
        Player.SetPosition(SpawnPoint.Position);

        UIManager = Instantiate(m_uiManagerPrefab);
        UIManager.Initialize(this);
    }

    private void Update()
    {
        if (Player.transform.position.y < m_deathHeight)
            Player.Die();
    }

    public void RunStart()
    {
        IsRunning = true;
        Player.ResetValues();
        a_runStart?.Invoke();
    }

    public void RunReset()
    {
        PlayerPrefs.SetFloat("MoveSpeed", Data.MoveSpeed);
        PlayerPrefs.SetFloat("SprintDuration", Data.SprintDuration);
        PlayerPrefs.SetInt("SprintSpeedMultiplier", Data.SprintSpeedMultiplier);
        PlayerPrefs.SetFloat("JumpForce", Data.JumpForce);
        PlayerPrefs.SetFloat("Gravity", Data.Gravity);
        
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
