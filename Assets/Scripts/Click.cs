using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Click : MonoBehaviour
{
    [SerializeField] private CircleView _circleView;
    [SerializeField] private int _minDist;
    private  Vector3 _clickPosition;
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

        if (Vector3.Distance(_circleView.transform.position, _clickPosition) > _minDist)
        {
            _circleController.ChangePosition(_clickPosition);
        }
    }

    private void ClickPosition(Vector3 click)
    {
        _clickPosition = click;
        _clickPosition.z = 0;
    }
}
