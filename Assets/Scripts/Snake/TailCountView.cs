using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Snake))]
public class TailCountView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    private Snake _snake;

    private void Awake()
    {
        _snake = GetComponent<Snake>();
    }

    private void OnEnable()
    {
        _snake.TailSizeUpdated += OnTailSizeUpdated;
    }

    private void OnDisable()
    {
        _snake.TailSizeUpdated -= OnTailSizeUpdated;
    }

    private void OnTailSizeUpdated(int size)
    {
        _view.text = size.ToString();
    }
}
