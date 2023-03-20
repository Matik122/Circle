using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class Square : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
        ActivationDelay();
    }   

    private void OnDisable()
    {
        transform.position = new Vector3(Random.Range(-14, 14), Random.Range(-6, 7), 0);
        ActivationDelay();
    }

    private async void ActivationDelay()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(Random.Range(10,50)), ignoreTimeScale: false);
        gameObject.SetActive(true);
    }
}
