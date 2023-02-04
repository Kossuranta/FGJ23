using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField]
    private Slider m_runSpeed;

    [SerializeField]
    private Slider m_jumpHeight;

    [SerializeField]
    private Slider m_sprintSpeed;

    [SerializeField]
    private Slider m_gravity;

    private Data m_data;

    // Start is called before the first frame update
    void Start()
    {
    //    m_runSpeed = MoveSpeed;
    //    m_jumpHeight = JumpForce;
    //    m_sprintSpeed = SprintSpeedMultiplier;
    //    m_gravity = Gravity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
