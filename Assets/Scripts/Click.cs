using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Click : MonoBehaviour
{ 
    public Vector3 clickPosition;
    [SerializeField] private CircleView _circleView;
    private CirlcleController _circleController;

    private void Start()
    {
        _circleController = new CirlcleController(new CircleModel(), _circleView);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                clickPosition = hit.point;
                clickPosition.z = 0;
            }
        }
        
        _circleController.model.ChangePosition(clickPosition);
    }
}
