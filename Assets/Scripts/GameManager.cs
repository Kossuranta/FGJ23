using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Data Data { get; private set; }

    private void Awake()
    {
        Data = new Data();
    }
}
