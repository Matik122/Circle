using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IOblectVectorMovable
{
    [SerializeField] private GameObject _whole;
    [SerializeField] private GameObject _sliced;
    [SerializeField] private GameObject _explosion;
    private Rigidbody _rigidBody;
    private Collider _fruitCollider;

    private void Start()
    {
        _rigidBody = this.gameObject.GetComponent<Rigidbody>();
        _fruitCollider = this.gameObject.GetComponent<Collider>();
    }

    private void Update()
    {
        transform.Rotate(Constants.RotatingEarthConst, Constants.RotatingAsteroidConst, Constants.RotatingEarthConst);
        MoveObjectToTarget();

        if (Time.timeScale == 0)
        {
            enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.Direction,blade.transform.position,Constants.SliceForce);
            ScoreController.instance.AddPoints();
        }
        else if (other.CompareTag("Earth"))
        {
            Earth earth = other.GetComponent<Earth>();

            if (!PlayerPrefs.HasKey("AsteroidsCollision"))
            {
                PlayerPrefs.SetInt("AsteroidsCollision", Constants.FirstIndexAchieve);
            }
            else
            {
                PlayerPrefs.SetInt("AsteroidsCollision", PlayerPrefs.GetInt("AsteroidsCollision") + Constants.FirstIndexAchieve);
            }
            earth.CheckForDeathPoints(PlayerPrefs.GetInt("AsteroidsCollision"));
            Destroy(this.gameObject);
        }
    }


    private void Slice(Vector3 direction,Vector3 position,float force)
    {
        _fruitCollider.enabled = false;
        _whole.SetActive(false);
        _sliced.SetActive(true);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _sliced.transform.rotation = Quaternion.Euler(0, 0, angle);
        Rigidbody[] slices = _sliced.GetComponentsInChildren<Rigidbody>();
        _explosion.SetActive(true);

        foreach(Rigidbody slice in slices)
        {
            slice.velocity = _rigidBody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }

    public void MoveObjectToTarget()
    {
        float step = Constants.MoveTowardsStepIndex * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Earth.EarthVector, step);
    }
}
