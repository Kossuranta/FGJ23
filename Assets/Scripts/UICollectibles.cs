using UnityEngine;
using UnityEngine.UI;

public class UICollectibles : MonoBehaviour
{
    [SerializeField]
    private Image[] m_icons;

    private bool[] m_collected;

    private void Awake()
    {
        foreach (Image icon in m_icons)
        {
            icon.color = Color.black;
        }

        m_collected = new bool[m_icons.Length];
    }

    private void Update()
    {
        GameManager gameManager = GameManager.Instance;
        for (int i = 0; i < m_icons.Length; i++)
        {
            if (m_collected[i])
                continue;

            if (gameManager.Collectibles[i])
            {
                m_icons[i].color = Color.white;
                m_collected[i] = true;
            }
        }
    }
}
