using System;
using UnityEngine;

[Serializable]
public class CloudData
{
    [SerializeField]
    private Transform m_prefab = null;

    [SerializeField]
    private float m_minHeight = 10f;

    [SerializeField]
    private float m_maxHeight = 20f;

    public Transform Prefab => m_prefab;
    public float MinHeight => m_minHeight;
    public float MaxHeight => m_maxHeight;
}

[CreateAssetMenu(menuName = "Cthulhu/CloudConfigure")]
public class CloudConfigure : ScriptableObject
{
    [SerializeField]
    private CloudData[] m_clouds = null;

    [SerializeField]
    private float m_minSpeed = 1f;

    [SerializeField]
    private float m_maxSpeed = 5f;

    [SerializeField]
    private int m_count = 30;

    [SerializeField]
    private float m_maxPosX = 13f;
    
    public CloudData[] Clouds => m_clouds;
    public float MinSpeed => m_minSpeed;
    public float MaxSpeed => m_maxSpeed;
    public int Count => m_count;
    public float MaxPosX => m_maxPosX;
}