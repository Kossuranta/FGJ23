using System;
using UnityEngine;

public class JumpNode : MonoBehaviour
{
    private GameManager m_gameManager;
    private float m_jumpForce;

    private void Start()
    {
        m_gameManager = GameManager.s_gameManager;
        m_jumpForce = m_gameManager.Data.JumpForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
