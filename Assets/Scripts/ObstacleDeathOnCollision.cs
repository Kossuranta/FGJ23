using UnityEngine;

public class ObstacleDeathOnCollision : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D _collision)
    {   
        PlayerMovement playerMovement = _collision.transform.GetComponent<PlayerMovement>();
        if (playerMovement == null)
            return;
        
        playerMovement.Die();
    }
    
}
