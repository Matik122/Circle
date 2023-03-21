using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class Square : MonoBehaviour
{
    [SerializeField] private int _scoreCount;
    [SerializeField] private int _minSpawnValue;
    [SerializeField] private int _maxSpawnValue;
    
    private InterfaceEncounters _uiInterfaceEncounters;

    [Inject]
    public void Construct(InterfaceEncounters interfaceEncounters)
    {
        _uiInterfaceEncounters = interfaceEncounters;
    }
    
    public void StartAfterPool()
    {
        Construct(_uiInterfaceEncounters);
        ActivationDelay();
    }
    
    public void Deactivate(bool isActive)
    {
        gameObject.SetActive(isActive);
        _uiInterfaceEncounters.AddValue(_scoreCount,ref _uiInterfaceEncounters.TotalScore,
            _uiInterfaceEncounters.Score,Constants.HighScoreDefinition);
        transform.position = VectorUtils.RandomPosition();
        ActivationDelay();
    }
    
    private async void ActivationDelay()
    {
        try
        {
            await UniTask.Delay(TimeSpan.FromSeconds(Random.Range(_minSpawnValue, _maxSpawnValue)), ignoreTimeScale: false);
            gameObject.SetActive(true);
        }
        catch (Exception e)
        {
            Debug.Log($"Exception while opening file from device {e.Message}");
        }
    }
}