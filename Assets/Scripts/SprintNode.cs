public class SprintNode : BaseNode
{
    private float m_sprintDuration;
    private int m_sprintSpeedMultiplier;
    
    protected override void Initialize()
    {
        m_sprintDuration = m_data.SprintDuration;
        m_sprintSpeedMultiplier = m_data.SprintSpeedMultiplier;
    }

    protected override void Activate(PlayerMovement _playerMovement)
    {
        _playerMovement.Sprint();
    }
}