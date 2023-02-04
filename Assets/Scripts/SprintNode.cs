public class SprintNode : BaseNode
{
    protected override void Initialize() { }

    protected override void Activate(PlayerMovement _playerMovement)
    {           
        _playerMovement.Sprint();
    }
}