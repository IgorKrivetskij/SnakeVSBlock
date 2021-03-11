using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeHead : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Snake _snake;

    public event UnityAction BlockCollided;
    public event UnityAction<int> BonusCollected;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _snake = GetComponentInParent<Snake>();
    }

    public void Moove(Vector3 newPosition)
    {
        _rigidbody2D.MovePosition(newPosition);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Block>(out Block block) && _snake.TailCount !=0)
        {
            BlockCollided?.Invoke();
            block.Fill();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bonus>(out Bonus bonus))
        {
            BonusCollected?.Invoke(bonus.Collect());
        }
    }
}
