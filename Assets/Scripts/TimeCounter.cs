using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private Text _timeText;
    private float _timeCount = 0f;

    public int TimeCount => (int)_timeCount;

    private void Update()
    {
        _timeCount += Time.deltaTime;
        _timeText.text = ((int)_timeCount).ToString();
    }
}
