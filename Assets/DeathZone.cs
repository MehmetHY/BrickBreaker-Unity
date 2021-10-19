using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private LevelManager _levelManager;
    private Ball _ball;
    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _ball = FindObjectOfType<Ball>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            MissBall();
        }
    }

    private void MissBall()
    {
        _ball.BackToLaunch();
        _levelManager.DecreasePlayerHealth();
    }
}
