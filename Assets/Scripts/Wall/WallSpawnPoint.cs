using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnPoint : SpawnPoint
{
    private float _offsetY;

    private void Awake()
    {
        _offsetY = Random.Range(2, 5);
        transform.position = new Vector3(transform.position.x, transform.position.y- _offsetY, transform.position.z);
    }
}
