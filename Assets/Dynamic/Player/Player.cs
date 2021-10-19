using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _leftBound;
    [SerializeField] private Transform _rightBound;
    [SerializeField] private Ball _ball;

    [SerializeField] private float _linearDrag = 0.1f;
    [SerializeField] private float _acceleration = 10.0f;
    [SerializeField] private float _maxSpeed = 20.0f;

    private Vector2 moveInput;
    private Rigidbody2D _rb;
    private const float ACC_MULTIPLIER = 100.0f;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void LateUpdate()
    {
        ApplyDrag();
        HandleMove();
        HandleBounds();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    private void ApplyDrag()
    {
        if (_rb.velocity.x < 0)
        {
            _rb.velocity += new Vector2(_linearDrag, 0.0f);
            if (_rb.velocity.x > 0)
            {
                _rb.velocity = new Vector2(0, 0);
            }
        }
        else
        {
            _rb.velocity -= new Vector2(_linearDrag, 0.0f);
            if (_rb.velocity.x < 0)
            {
                _rb.velocity = new Vector2(0, 0);
            }
        }
    }
    private void HandleMove()
    {
        _rb.velocity += moveInput * Time.deltaTime * _acceleration * ACC_MULTIPLIER;
        _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -_maxSpeed, _maxSpeed), 0.0f);
    }
    private void OnFire()
    {
        _ball.Launch();
    }
    private void HandleBounds()
    {
        if (transform.position.x < _leftBound.position.x)
        {
            transform.position = new Vector2(_leftBound.position.x, transform.position.y);
        }
        else if (transform.position.x > _rightBound.position.x)
        {
            transform.position = new Vector2(_rightBound.position.x, transform.position.y);
        }
    }
}
