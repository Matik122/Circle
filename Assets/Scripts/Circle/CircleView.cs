using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleView : MonoBehaviour
{
    [SerializeField] private float _speed;
    public void SetPosition(Vector3 endPostion)
    {
        transform.position = Vector3.MoveTowards(transform.position, endPostion,_speed * Time.deltaTime);
    }
    
    
}
