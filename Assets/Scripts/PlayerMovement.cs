using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float playerSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * playerSpeed);
    }

    public void SetPosition(Vector3 _pos)
    {
        transform.position = _pos;
    }

    public void Jump(float _force)
    {
        
    }

    public void Sprint()
    {
        
    }
}
