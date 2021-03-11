using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    public Vector2 GetDirectionOnClick(Vector2 headPosition)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = _mainCamera.ScreenToViewportPoint(mousePosition);
        mousePosition.y = 1;
        mousePosition = _mainCamera.ViewportToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - headPosition.x, mousePosition.y - headPosition.y);
        return direction;
    }
}
