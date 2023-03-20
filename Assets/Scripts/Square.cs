using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class Square : MonoBehaviour
{
    [SerializeField] private int _scoreCount;
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
            _uiInterfaceEncounters.Score,"HighScore");
        transform.position = new Vector3(Random.Range(-14, 14), Random.Range(-6, 7), 0);
        ActivationDelay();
    }
    

    private async void ActivationDelay()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(Random.Range(2,15)), ignoreTimeScale: false);
        gameObject.SetActive(true);
    }
}
