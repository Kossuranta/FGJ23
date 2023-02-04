using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [SerializeField]
    private CloudConfigure m_cloudConfigure = null;

    private List<(Transform cloud, CloudData data, float speed)> m_clouds = null;

    private void Awake()
    {
        if (m_cloudConfigure == null)
        {
            Debug.LogError("cloudConfigure is null!", this);
            enabled = false;
        }
        
        if (m_cloudConfigure.Clouds.Length == 0)
        {
            Debug.LogError("CloudConfigure has no clouds added!", this);
            enabled = false;
        }
    }

    private void Start()
    {
        InstantiateClouds();
    }

    private void InstantiateClouds()
    {
        m_clouds = new List<(Transform cloud, CloudData data, float speed)>(m_cloudConfigure.Count);
        for (int i = 0; i < m_cloudConfigure.Count; i++)
        {
            int rng = Random.Range(0, m_cloudConfigure.Clouds.Length - 1);
            CloudData data = m_cloudConfigure.Clouds[rng];

            Transform cloud = Instantiate(data.Prefab, transform, false);
            Vector2 pos = Vector2.zero;
            pos.x = Random.Range(-30f, 30f);
            pos.y = Random.Range(data.MinHeight, data.MaxHeight);
            cloud.transform.localPosition = pos;

            float speed = Random.Range(m_cloudConfigure.MinSpeed, m_cloudConfigure.MaxSpeed);
            m_clouds.Add((cloud, data, speed));
        }
    }

    private void Update()
    {
        foreach ((Transform cloud, CloudData data, float speed) in m_clouds)
        {
            Vector2 pos = cloud.localPosition;
            pos.x += Time.deltaTime * speed;

            if (pos.x > m_cloudConfigure.MaxPosX)
            {
                pos.x = -m_cloudConfigure.MaxPosX;
                pos.y = Random.Range(data.MinHeight, data.MaxHeight);
            }

            cloud.localPosition = pos;
        }
    }
}
