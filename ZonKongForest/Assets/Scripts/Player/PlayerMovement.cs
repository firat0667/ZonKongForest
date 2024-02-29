using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _moveDirection;

    public float Speed = 5f;
    private float _gravity = 20f;

    public float JumpForce = 10f;
   [SerializeField] private float _verticalVelocity;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
    }
    public void MoveThePlayer()
    {
        _moveDirection = new Vector3(Input.GetAxis(EasyAxis.HORIZONTAL), 0f, Input.GetAxis(EasyAxis.VERTICAL));

        _moveDirection = transform.TransformDirection(_moveDirection);
        _moveDirection*=Speed*Time.deltaTime;
        ApplyGravity();
        _characterController.Move(_moveDirection);
       
    }
    void ApplyGravity()
    {
        if (_characterController.isGrounded)
        {
            _verticalVelocity -= _gravity * Time.deltaTime;
            // jump
            PlayerJump();
        }
        else
        {
            _verticalVelocity -= _gravity * Time.deltaTime;
        }
        _moveDirection.y = _verticalVelocity*Time.deltaTime;
    }
    void PlayerJump()
    {
        if(_characterController.isGrounded&&Input.GetKeyDown(KeyCode.Space)) 
        {
            _verticalVelocity = JumpForce;
        }
    }
}
