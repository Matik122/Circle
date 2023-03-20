using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public Vector3 moveToPositon;
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveToPositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
