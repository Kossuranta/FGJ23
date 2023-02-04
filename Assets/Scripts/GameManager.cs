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
    public Data Data { get; private set; }

    private void Awake()
    {
        Instance = this;
        if (s_instance != this)
            return;
        Data = new Data();
    }
}
