using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider HealthSlider;
    public Slider StaminaSlider;
    private HealthScript _health;
    private PlayerSprintAndCrouch _sprintAndCrouch;

    void Start()
    {
        _health = GetComponent<HealthScript>();
        _sprintAndCrouch=GetComponent<PlayerSprintAndCrouch>();
        StaminaSlider.minValue = 0;
        StaminaSlider.maxValue = 100;
        HealthSlider.maxValue = 100;
        HealthSlider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HealthSlider.value = _health.Health;
        StaminaSlider.value = _sprintAndCrouch.SprintValue;

    }
}
