using UnityEngine;

public class Data
{
    public float MoveSpeed { get; set; } = 7.3f;
    public float SprintDuration { get; set; } = 3.5f;
    public int SprintSpeedMultiplier { get; set; } = 5;
    public float JumpForce { get; set; } = 20.5f;

    private float m_gravity = 6.7f;
    public float Gravity
    {
        get => m_gravity;
        set
        {
            m_gravity = value;
            Physics2D.gravity = new Vector2(0, value);
        }
    }
}
