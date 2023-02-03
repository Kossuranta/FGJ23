public class JumpNode : BaseNode
{
    private float m_jumpForce;

    protected override void Initialize()
    {
        m_jumpForce = m_data.JumpForce;
    }

    protected override void Activate(PlayerMovement _playerMovement)
    {
        _playerMovement.Jump(m_jumpForce);
    }
}
