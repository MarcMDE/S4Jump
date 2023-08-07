using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private float _jumpForce;

    [SerializeField]
    private float _gravityAcc;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance;
    [SerializeField] private LayerMask _groundMask;

    private Vector3 _velocity;

    private bool _isJumping;
    private bool _isGrounded;
    
    private CharacterController _characterController;

    public event Action OnJump;


    void Start()
    {
        _isGrounded = false;
        _isJumping = false;

        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontalInput/* + transform.forward * verticalInput*/;
        move *= _movementSpeed;

        if (_isGrounded)
        {
            _velocity.y = 0f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _velocity.y = _jumpForce;
                _isJumping = true;
                OnJump?.Invoke();
            }
        }

        _velocity.y += _gravityAcc * Time.deltaTime;
        _characterController.Move((move + _velocity) * Time.deltaTime);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundCheck.position, _groundDistance);
    }
#endif
}
