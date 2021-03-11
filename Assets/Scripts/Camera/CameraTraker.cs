using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTraker : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _yOffset;
    private SnakeHead _snakeHead;

    private void Start()
    {
        _snakeHead = FindObjectOfType<SnakeHead>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, GetMoovePosition(), _speed * Time.fixedDeltaTime);
    }

    private Vector3 GetMoovePosition()
    {
        return new Vector3(transform.position.x, _snakeHead.transform.position.y + _yOffset, transform.position.z);
    }
}
