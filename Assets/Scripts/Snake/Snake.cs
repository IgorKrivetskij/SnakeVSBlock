using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TailGenerator))]
[RequireComponent(typeof(SnakeInput))]
public class Snake : MonoBehaviour
{
    [SerializeField] private float _mooveSpeed;
    [SerializeField] private float _segmentSpeed;
    [SerializeField] private SnakeHead _snakeHead;
    [SerializeField] private int _tailSize;
    [SerializeField] private GameObject _gameOverMenu;
    private SnakeInput _snakeInput;
    private  List<TailSegment> _tail;
    private TailGenerator _tailGenerator;

    public event UnityAction<int> TailSizeUpdated;
    public int TailCount => _tail.Count;

    private void Awake()
    {
        _tailGenerator = GetComponent<TailGenerator>();
        _snakeInput = GetComponent<SnakeInput>();
        _tail = _tailGenerator.GenerateStartTail(_tailSize, transform.position);
    }

    private void Start()
    {
        TailSizeUpdated?.Invoke(_tail.Count);
    }

    private void OnEnable()
    {
        _snakeHead.BlockCollided += OnBlockCollided;
        _snakeHead.BonusCollected += OnBonusCollected;
    }

    private void OnDisable()
    {
        _snakeHead.BlockCollided -= OnBlockCollided;
        _snakeHead.BonusCollected -= OnBonusCollected;
    }

    private void Update()
    {
        if(_tail.Count == 0)
        {
            Death();
        }
    }

    private void FixedUpdate()
    {
        Moove(_snakeHead.transform.position + _snakeHead.transform.up * _mooveSpeed * Time.fixedDeltaTime);
        _snakeHead.transform.up = _snakeInput.GetDirectionOnClick(_snakeHead.transform.position);
    }

    private void Moove(Vector3 nextPosition)
    {
        Vector3 previosPosition = _snakeHead.transform.position;

        foreach (var segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector2.Lerp(tempPosition, previosPosition, _segmentSpeed * Time.fixedDeltaTime);
            previosPosition = tempPosition;
        }
        _snakeHead.Moove(nextPosition);
    }

    private void OnBlockCollided()
    {
        TailSegment deletSegment = _tail[_tail.Count - 1];
        _tail.RemoveAt(_tail.Count - 1);
        Destroy(deletSegment.gameObject);
        TailSizeUpdated?.Invoke(_tail.Count);
    }

    private void OnBonusCollected(int bonusSize)
    {
        _tail.AddRange(_tailGenerator.GenerateStartTail(bonusSize, _tail[TailCount-1].transform.position));
        TailSizeUpdated?.Invoke(_tail.Count);
    }

    private void Death()
    {
        _gameOverMenu.SetActive(true);
    }
}
