using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Range(0.1f, 10.0f)][SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _maxSpeed = 20.0f;
    private Vector2 moveInput;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void LateUpdate()
    {
        HandleMove();        
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void HandleMove()
    {
        _rb.AddForce(moveInput * _speed * Time.deltaTime * 50);
        _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -_maxSpeed, _maxSpeed), Mathf.Clamp(_rb.velocity.y, -_maxSpeed, _maxSpeed));
    }
}
