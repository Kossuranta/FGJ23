using UnityEngine;

public class Data
{
    // Default values won't work anymore, use sliders!
    public float MoveSpeed { get; set; }
    public float SprintDuration { get; set; }
    public int SprintSpeedMultiplier { get; set; }
    public float JumpForce { get; set; }

    private float m_gravity;
    public float Gravity
    {
        get => m_gravity;
        set
        {
            m_gravity = value;
            Physics2D.gravity = new Vector2(0, -value);
        }
    }
}
