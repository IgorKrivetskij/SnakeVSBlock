using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bonus : Element
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private Vector2Int _bonusRange;
    private int _bonusSize;

    private void Awake()
    {
        _bonusSize = Random.Range(_bonusRange.x, _bonusRange.y);
        _view.text = _bonusSize.ToString();
    }

    public int  Collect()
    {
        Destroy(gameObject);
        return _bonusSize;
    }
}
