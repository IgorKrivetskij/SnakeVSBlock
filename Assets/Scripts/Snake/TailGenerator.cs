using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailGenerator : MonoBehaviour
{    
    [SerializeField] private TailSegment _tailSegment;
    
    public List<TailSegment> GenerateStartTail(int count, Vector3 generatePosition)
    {
        List<TailSegment> tail = new List<TailSegment>();
        for (int i = 0; i < count; i++)
        {
            tail.Add(Instantiate(_tailSegment, generatePosition, Quaternion.identity, transform));
        }
        return tail;
    }    
}
