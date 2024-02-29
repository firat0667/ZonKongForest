using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintAndCrouch : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement _playerMovement;
    private Transform _lookRoot;

    public float SprintSpeed = 10f;
    public float MoveSpeed = 5f;
    public float CrouchSpeed = 2f;

    private float StandHeight = 1.6f;
    private float CrouchHeight = 1f;

    private bool _isCouching;

    [Header("Foot Step Sound")]
    private PlayerFootSteps _footSteps;
    private float _sprintVolume = 1f;
    private float _crouchVolume = .1f;
    private float _walkVolumeMin = .2f;
    private float _walkVolumeMax = .6f;

    private float _walkStepDistance = .4f;
    private float _springStepDistance = .25f;
    private float _crouchStepDistance = .5f;
    private PlayerStats _playerStats;
    public float SprintValue = 100;
    public float SprintTreshold = 10f;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _lookRoot = transform.GetChild(0);
        _footSteps = GetComponentInChildren<PlayerFootSteps>();
        _playerStats = GetComponent<PlayerStats>();
    }
    void Start()
    {
        BaseFootSound();
    }

    private void BaseFootSound()
    {
        _footSteps.Volume_Min = _walkVolumeMin;
        _footSteps.Volume_Max = _walkVolumeMax;
        _footSteps.StepDistance = _walkStepDistance;
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }
    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !_isCouching)
        {
            // Sol Shift tuþuna basýldýðýnda sprint yap
            _playerMovement.Speed = SprintSpeed;

            _footSteps.StepDistance = _springStepDistance;
            _footSteps.Volume_Min = _sprintVolume;
            _footSteps.Volume_Max = _sprintVolume;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && !_isCouching)
        {
            // Sol Shift tuþu býrakýldýðýnda sprint sona ersin
            _playerMovement.Speed = MoveSpeed;
            BaseFootSound();
        }

        if (Input.GetKey(KeyCode.LeftShift) && !_isCouching)
        {
            // Sol Shift tuþu basýlý tutuluyorsa SprintValue deðeri azalsýn
            SprintValue -= Time.deltaTime * SprintTreshold;

            if (SprintValue <= 0)
            {
                // SprintValue deðeri 0'dan küçük veya eþitse sprint sona ersin
                SprintValue = 0;
                _playerMovement.Speed = MoveSpeed;
                BaseFootSound();
            }
        }
        else
        {
            // Sol Shift tuþu basýlmýyorsa SprintValue deðeri yavaþça artsýn
            if (SprintValue < 100)
            {
                SprintValue += (SprintTreshold / 2f) * Time.deltaTime;
                if (SprintValue > 100)
                    SprintValue = 100;
            }
        }
    }

    void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.C)|| Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (_isCouching)
            {
                _lookRoot.localPosition = new Vector3(0f, StandHeight, 0f);
                BaseFootSound();
                _playerMovement.Speed = MoveSpeed;
                _isCouching = false;
            }
            else
            {
                _lookRoot.localPosition = new Vector3(0f, CrouchHeight, 0f);
                _playerMovement.Speed = CrouchSpeed;

                _footSteps.StepDistance = _crouchStepDistance;
                _footSteps.Volume_Min = _crouchVolume;
                _footSteps.Volume_Max = _crouchVolume;

                _isCouching = true;
            }
            
        }
           
    }
}
