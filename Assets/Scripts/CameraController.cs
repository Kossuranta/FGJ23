using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera m_camera = null;
    
    [SerializeField]
    private float m_dampTime = 0.15f;

    [SerializeField]
    private Vector3 m_cameraOffset = new (6f, 0, -10f);

    private PlayerMovement m_player = null;
    private Vector3 m_velocity = Vector3.zero;
    
    public bool IsFollowing { get; set; }

    public void Initialize(PlayerMovement _player)
    {
        m_player = _player;
    }

    private void FixedUpdate()
    {
        if (m_player == null) return;
        if (m_camera == null) return;
        if (!IsFollowing) return;

        Vector3 playerPos = m_player.transform.localPosition + m_cameraOffset;
        Vector3 point = m_camera.WorldToViewportPoint(playerPos);
        Vector3 delta = playerPos - m_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 cameraPos = transform.localPosition;
        Vector3 destination = cameraPos + delta;
        cameraPos = Vector3.SmoothDamp(cameraPos, destination, ref m_velocity, m_dampTime);

        cameraPos.y = Mathf.Clamp(cameraPos.y, -50f, float.PositiveInfinity);
        transform.localPosition = cameraPos;
    }
}
