using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public Vector3 Direction => _direction;
    [SerializeField] private GameObject _bladeTrail;
    private TrailRenderer _trail;
    private Vector3 _direction;
    private Camera _mainCamera;
    private bool _isSlicing;
    private Collider _cicrleCollider;

    private void Start()
    {
        _mainCamera = Camera.main;
        _cicrleCollider = this.gameObject.GetComponent<Collider>();
        _trail = this.gameObject.GetComponentInChildren<TrailRenderer>();
        _cicrleCollider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if (_isSlicing)
        {
            ContinueSlicing();
        }
    }

    private void StartSlicing()
    {
        Vector3 newPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        transform.position = newPosition;
        _isSlicing = true;
        _cicrleCollider.enabled = false;
        _trail.enabled = true;
        _trail.Clear();
    }

    private void StopSlicing()
    {
        _isSlicing = false;
        _trail.enabled = false;
        _cicrleCollider.enabled = false;
    }

    private void ContinueSlicing()
    {
        Vector3 newPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        _direction = newPosition - transform.position;
        float velocity = _direction.magnitude * Time.deltaTime;
        _cicrleCollider.enabled = velocity > Constants.MinCuttingVelocity;
        transform.position = newPosition;
        _cicrleCollider.enabled = true;
    }

}
