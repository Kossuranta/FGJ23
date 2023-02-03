using UnityEngine;

public class PlayerMovement : MonoBehaviour
{      
    [SerializeField]
    private Rigidbody2D m_rigidbody;
    private float m_moveSpeed;
    private GameManager m_gameManager;


    // Start is called before the first frame update
    private void Start()
    {
        m_gameManager = GameManager.s_gameManager;
        m_moveSpeed = m_gameManager.Data.MoveSpeed;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_rigidbody.MovePosition(transform.position * Time.deltaTime * m_moveSpeed);
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
