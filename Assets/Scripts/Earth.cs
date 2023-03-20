using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public static Vector3 EarthVector => _earthVector;
    [SerializeField] private GameObject[] _deathPoints;
    [SerializeField] private GameObject _deathText;
    [SerializeField] private Blade _blade;
    private static Vector3 _earthVector;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = Constants.FirstIndexAchieve;
        _earthVector = transform.position;
    }

    private void Update()
    {
        transform.Rotate(0, Constants.RotatingEarthConst, 0);
    }

    public void CheckForDeathPoints(int collisionCounts)
    {
        for (int i = 0; i < collisionCounts; i++)
        {
            _deathPoints[i].SetActive(true);
        }

        if(collisionCounts == Constants.DeathPointsLimit)
        {
            _deathText.SetActive(true);
            _blade.enabled = false;
            Time.timeScale = 0;
            enabled = false;
        }
    }
}
