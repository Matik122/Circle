using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants 
{
    public const float MinSpawnDelay = 0.25f;
    public const float MaxSpawnDelay = 1f;
    public const float MinAngle = -15f;
    public const float MaxAngle = 15f;
    public const float MinForce = 10f;
    public const float MaxForce = 15f;
    public const float MaxLifeTime = 25f;
    public const float MinCuttingVelocity = 0.01f;
    public const float SliceForce = 5f;
    public const float RotatingEarthConst = 0.1f;
    public const float RotatingAsteroidConst = 0.5f;
    public const float DeathPointsLimit = 3;
    public const float SpawnRate = 2f;
    public const float SpawnerTimeInstantiationRate = 3f;
    public const float SpawnerTimeInstantiationRateFirstStage = 1f;
    public const float SpawnerTimeInstantiationRateSecondStage = 0.5f;
    public const float SpawnerTimeInstantiationRateThirdStage = 0.2f;
    public const float AsteroidMassFirstStage = 6f;
    public const float AsteroidMassSecondStage = 4f;
    public const float AsteroidMassThirdStage = 3f;
    public const float MoveTowardsStepIndex = 1.5f;
    public const int ScoreIncrement = 10;
    public const int FirstStagePoint = 100;
    public const int SecondStagePoint = 500;
    public const int ThirdStagePoint = 1000;
    public const int FirstIndexAchieve = 1;
}
