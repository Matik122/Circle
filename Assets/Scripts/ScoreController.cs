using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Spawner _spawner;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddPoints()
    {
        if (!PlayerPrefs.HasKey("Score"))
        { 
            PlayerPrefs.SetInt("Score", Constants.ScoreIncrement);
        }
        else
        {
            int score = PlayerPrefs.GetInt("Score") + Constants.ScoreIncrement;
            PlayerPrefs.SetInt("Score", score);
        }

        _scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        CheckForCurrentStage();
    }

    private void CheckForCurrentStage()
    {
        switch (PlayerPrefs.GetInt("Score"))
        {
            case Constants.FirstStagePoint:
                SetUpStage(Constants.SpawnerTimeInstantiationRateFirstStage,
                delegate
                { SetAsteroidsMass(_spawner.asteroids, Constants.AsteroidMassFirstStage);});
                break;
            case Constants.SecondStagePoint:
                SetUpStage(Constants.SpawnerTimeInstantiationRateSecondStage,
                delegate
                { SetAsteroidsMass(_spawner.asteroids, Constants.AsteroidMassSecondStage);});
                break;
            case Constants.ThirdStagePoint:
                SetUpStage(Constants.SpawnerTimeInstantiationRateThirdStage,
                delegate
                { SetAsteroidsMass(_spawner.asteroids, Constants.AsteroidMassThirdStage);});
                break;
        }
    }

    private void SetUpStage(float spawnRate,Action asteroidMassSet)
    {
        _spawner.SpawnerTimeInstantiationRate = spawnRate;
        asteroidMassSet?.Invoke();
    }

    private void SetAsteroidsMass(GameObject[] asteroids,float massIndex)
    {
        for (int i = 0; i < asteroids.Length; i++)
        {
            asteroids[i].GetComponent<Rigidbody>().mass = massIndex;
        }
    }

}
