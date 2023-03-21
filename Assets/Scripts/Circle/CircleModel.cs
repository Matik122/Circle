using System;
using UnityEngine;

public class CircleModel
{ 
    public event Action<Vector3> OnPositionChanged;
    private Vector3 _currentPosition;

    public CircleModel(Vector3 currentPosition)
    {
        _currentPosition = currentPosition;
    }
    
    public void ChangeModelPosition(Vector3 changePosition)
    {
        _currentPosition = changePosition;
        OnPositionChanged?.Invoke(_currentPosition);
    }
}
