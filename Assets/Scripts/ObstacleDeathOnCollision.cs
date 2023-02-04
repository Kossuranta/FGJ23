using UnityEngine;

public class ObstacleDeathOnCollision : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D _collision)
    {   
        PlayerMovement playerMovement = _collision.transform.GetComponent<PlayerMovement>();

        if (playerMovement == null)
        {
            Debug.LogError("OnCollisionEnter2D called, but other collider doesn't have PlayerMovement component!");
            return;
        }
        
        playerMovement.Die();
    }
    
}
