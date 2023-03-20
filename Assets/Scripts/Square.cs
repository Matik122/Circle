using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Square : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Wait(Random.Range(10, 50)));
    }

    private void OnDisable()
    {
       
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(true);
    }
}
