using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleModel
{ 
    public event Action<Vector3> OnPositionChanged;
    
    public void ChangeModelPosition(Vector3 changePosition)
    {
        OnPositionChanged?.Invoke(changePosition);
    }

}
