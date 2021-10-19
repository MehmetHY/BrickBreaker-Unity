using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private int _health = 1;
    [SerializeField] static private readonly Color32 HEALTH_1_COLOR = new Color(1.0f, 0.5f, 0.5f);
    [SerializeField] static private readonly Color32 HEALTH_2_COLOR = new Color(1.0f, 1.0f, 0.5f);
    [SerializeField] static private readonly Color32 HEALTH_3_COLOR = new Color(0.5f, 1.0f, 0.5f);

    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeColor();
    }

    private void ChangeColor()
    {
        switch (_health)
        {
            case 1:
                _spriteRenderer.color = HEALTH_1_COLOR;
                break;
            case 2:
                _spriteRenderer.color = HEALTH_2_COLOR;
                break;
            case 3:
                _spriteRenderer.color = HEALTH_3_COLOR;
                break;
        }
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        _health--;
        ChangeColor();
        if (_health < 1)
        {
            Destroy(gameObject);
        }
    }
}
