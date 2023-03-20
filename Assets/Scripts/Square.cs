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
    private InterfaceEncounters _uiInterfaceEncounters;

    [Inject]
    public async void Construct(InterfaceEncounters interfaceEncounters)
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
        _uiInterfaceEncounters.AddScore(1);
        transform.position = new Vector3(Random.Range(-14, 14), Random.Range(-6, 7), 0);
        ActivationDelay();
    }
    

    private async void ActivationDelay()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(Random.Range(5,20)), ignoreTimeScale: false);
        gameObject.SetActive(true);
    }
}
