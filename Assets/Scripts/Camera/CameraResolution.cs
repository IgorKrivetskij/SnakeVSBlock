using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    private Camera _camera;
    private float _defaultWidht;

    private void Start()
    {
        _camera = Camera.main;
        _defaultWidht = _camera.orthographicSize * _camera.aspect;
    }

    private void Update()
    {
        _camera.orthographicSize = _defaultWidht / _camera.aspect;
    }
}
