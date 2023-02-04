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

    void Awake()
    {
        m_data = GameManager.Instance.Data;

        m_runSpeed.onValueChanged.AddListener(OnMoveSpeedChanged);
        m_jumpHeight.onValueChanged.AddListener(OnJumpSpeedChanged);
        m_sprintSpeed.onValueChanged.AddListener(OnSprintSpeedChanged);
        m_gravity.onValueChanged.AddListener(OnGravityChanged);
    }

    void OnMoveSpeedChanged(float _value)
    {
        m_data.MoveSpeed = m_runSpeed.value;
    }

    void OnJumpSpeedChanged(float _value)
    {
        m_data.JumpForce = m_jumpHeight.value;
    }

    void OnSprintSpeedChanged(float _value)
    {
        m_data.SprintSpeedMultiplier = Mathf.RoundToInt(m_sprintSpeed.value);
    }

    void OnGravityChanged(float _value)
    {
        m_data.Gravity = m_gravity.value;
    }
}
