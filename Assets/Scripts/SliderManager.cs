using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField]
    private Slider m_moveSpeed;

    [SerializeField]
    private TextMeshProUGUI m_moveSpeedValue;
    
    [SerializeField]
    private Slider m_sprintDuration;
    
    [SerializeField]
    private TextMeshProUGUI m_sprintDurationValue;

    [SerializeField]
    private Slider m_sprintSpeedMultiplier;
    
    [SerializeField]
    private TextMeshProUGUI m_sprintSpeedMultiplierValue;
    
    [SerializeField]
    private Slider m_jumpHeight;
    
    [SerializeField]
    private TextMeshProUGUI m_jumpHeightValue;

    [SerializeField]
    private Slider m_gravity;
    
    [SerializeField]
    private TextMeshProUGUI m_gravityValue;

    private Data m_data;

    public void Initialize(GameManager _gameManager)
    {
        m_data = _gameManager.Data;

        m_moveSpeed.value = m_data.MoveSpeed;
        OnMoveSpeedChanged(m_data.MoveSpeed);

        m_sprintDuration.value = m_data.SprintDuration;
        OnSprintDurationChanged(m_data.SprintDuration);
        
        m_sprintSpeedMultiplier.value = m_data.SprintSpeedMultiplier;
        OnSprintSpeedMultiplierChanged(m_data.SprintSpeedMultiplier);
        
        m_jumpHeight.value = m_data.JumpForce;
        OnJumpSpeedChanged(m_data.JumpForce);
        
        m_gravity.value = m_data.Gravity;
        OnGravityChanged(m_data.Gravity);

        m_moveSpeed.onValueChanged.AddListener(OnMoveSpeedChanged);
        m_sprintDuration.onValueChanged.AddListener(OnSprintDurationChanged);
        m_sprintSpeedMultiplier.onValueChanged.AddListener(OnSprintSpeedMultiplierChanged);
        m_jumpHeight.onValueChanged.AddListener(OnJumpSpeedChanged);
        m_gravity.onValueChanged.AddListener(OnGravityChanged);
    }

    private void OnMoveSpeedChanged(float _value)
    {
        m_moveSpeedValue.text = _value.ToString("F1");
        m_data.MoveSpeed = _value;
    }

    private void OnSprintDurationChanged(float _value)
    {
        m_sprintDurationValue.text = _value.ToString("F1");
        m_data.SprintDuration = _value;
    }

    private void OnSprintSpeedMultiplierChanged(float _value)
    {
        int value = Mathf.RoundToInt(_value);
        m_sprintSpeedMultiplierValue.text = $"x{value}";
        m_data.SprintSpeedMultiplier = value;
    }
    
    private void OnJumpSpeedChanged(float _value)
    {
        m_jumpHeightValue.text = _value.ToString("F1");
        m_data.JumpForce = _value;
    }

    private void OnGravityChanged(float _value)
    {
        m_gravityValue.text = _value.ToString("F1");
        m_data.Gravity = _value;
    }
}
