using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager s_gameManager; // Illegal singleton
    public Data Data { get; private set; }

    private void Awake()
    {
        s_gameManager = this;
        
        Data = new Data();
    }
}
