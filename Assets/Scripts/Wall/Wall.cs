using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Element
{
    private float _lenght;

    private void Awake()
    {
        _lenght = Random.Range(3, 6);
        transform.localScale = new Vector3(transform.localScale.x,_lenght ,transform.localScale.z);
    }
}
