using UnityEngine;

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
    private PlayerMovement m_playerPrefab;
    
    [SerializeField]
    private CameraController m_cameraPrefab;

    public SpawnPoint SpawnPoint { get; private set; }
    public Data Data { get; private set; }
    
    public PlayerMovement Player { get; private set; }
    public CameraController Camera { get; private set; }

    private void Awake()
    {
        Instance = this;
        if (s_instance != this)
            return;

        SpawnPoint = FindObjectOfType<SpawnPoint>();
        if (SpawnPoint == null)
            Debug.LogError("Scene is missing SpawnPoint!");

        Data = new Data();
    }

    private void Start()
    {
        Player = Instantiate(m_playerPrefab);
        Player.SetPosition(SpawnPoint.Position);

        Camera = Instantiate(m_cameraPrefab);
        Camera.Initialize(Player);
    }
}
