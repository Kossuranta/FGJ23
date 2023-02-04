using UnityEngine;

public class SprintNode : BaseNode
{
    protected override void Initialize() { }

    protected override void Activate(PlayerMovement _playerMovement)
    {   
        Debug.LogError("Mikään ei mennyt pieleen!");
        _playerMovement.Sprint();
        
    }
}