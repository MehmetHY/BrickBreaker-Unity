using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private float _launchSpeed = 10.0f;
    [SerializeField] private float _maxSpeed = 10.0f;
    [SerializeField] private float _randomForce = 1.0f;

    private bool isLaunched = false;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        FollowPlayer();
        ApplySpeedLimit();
    }

    private void ApplySpeedLimit()
    {
        if (_rb.velocity.magnitude > _maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
        }
    }

    private void FollowPlayer()
    {
        if (!isLaunched)
        {
            transform.position = new Vector2(_playerTransform.position.x, transform.position.y);
        }
    }

    public void Launch()
    {
        isLaunched = true;
        _rb.AddForce(new Vector2(Random.Range(-0.5f, 0.5f), 1.0f).normalized * _launchSpeed);
    }

    private void OnCollisionEnter2D(Collision2D _)
    {
        _rb.AddForce(new Vector2(Random.Range(-_randomForce, _randomForce), Random.Range(-_randomForce, _randomForce)));
    }
}
