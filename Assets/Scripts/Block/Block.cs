using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : Element
{
    [SerializeField] private Vector2Int _blockPriceRange;
    [SerializeField] private Color[] _colors;
    private SpriteRenderer _spriteRenderer;
    private int _destroyPrice;
    private int _fill;
    public int LeftToFill => _destroyPrice - _fill;
    public event UnityAction<int> FillingUpdater;

    private void Awake()
    {
        _destroyPrice = Random.Range(_blockPriceRange.x, _blockPriceRange.y);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetColor(_colors[Random.Range(0,_colors.Length)]);
    }

    private void Start()
    {
        FillingUpdater?.Invoke(LeftToFill);
    }

    public void Fill()
    {
        _fill++;
        FillingUpdater?.Invoke(LeftToFill);
        if (_fill == _destroyPrice)
        {
            Destroy(gameObject);
        }
    }

    private void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}
