using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    private AudioSource _footStepSound;
    private CharacterController _characterController;
    [HideInInspector]
    public float Volume_Min, Volume_Max;

    private float accumlated_Distance;

    [HideInInspector]
    public float StepDistance;

    [SerializeField]
    private AudioClip[] footstep_Clip;

    private void Awake()
    {
        _footStepSound= GetComponent<AudioSource>();
       _characterController = GetComponentInParent<CharacterController>();
    }
    private void Update()
    {
        CheckToPlayFootStepSound();
    }
    void CheckToPlayFootStepSound()
    {
        if (!_characterController.isGrounded)
            return;
        if (_characterController.velocity.sqrMagnitude > 0)
        {
            accumlated_Distance += Time.deltaTime;
            if (accumlated_Distance > StepDistance)
            {
                _footStepSound.volume = Random.Range(Volume_Min, Volume_Max);
                _footStepSound.clip = footstep_Clip[Random.Range(0, footstep_Clip.Length)];
                _footStepSound.Play();

                accumlated_Distance = 0;
            }
        }
        else
            accumlated_Distance = 0;
    }
}
