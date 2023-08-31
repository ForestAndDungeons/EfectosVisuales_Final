using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float _moveSpeed;
    [SerializeField] float _groundDrag;

    [Header("Ground Check")]
    [SerializeField] float _playerHeight;
    LayerMask _groundLayer;
    bool _grounded;

    [SerializeField] Transform _orientation;
    float _horizontalInput;
    float _verticalInput;
    Vector3 _moveDirection;
    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    void Update()
    {
        MyInput();
        SpeedControl();

        //Ground check.
        _grounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f, _groundLayer);
        _grounded = true;

        //Handle drag.
        if (_grounded)
            _rb.drag = _groundDrag;
        else
            _rb.drag = 0;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        //Calculate movement direction.
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;
        _rb.AddForce(_moveDirection.normalized * _moveSpeed * 10f, ForceMode.Force);
    }

    void SpeedControl()
    {
        Vector3 _flatVel = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        //Limit velocity if needed.
        if(_flatVel.magnitude > _moveSpeed)
        {
            Vector3 _limitedVel = _flatVel.normalized * _moveSpeed;
            _rb.velocity = new Vector3(_limitedVel.x, _rb.velocity.y, _limitedVel.z);
        }
    }
}
