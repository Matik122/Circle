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
                Vector3 tapPositon = hit.collider.gameObject.layer == _circleView.gameObject.layer ? 
                    _circleView.transform.position : hit.point;
                ClickPosition(tapPositon);
            }
        }
        
        _circleController.ChangePosition(clickPosition);
    }

    private void ClickPosition(Vector3 click)
    {
        clickPosition = click;
        clickPosition.z = 0;
    }
}
