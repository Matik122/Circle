using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquaresPool : MonoBehaviour
{
    [SerializeField] private int _poolCount;
    [SerializeField] private Square _square;
    private ObjectPoolingBehaviour<Square> _pool;

    private void Start()
    {
        _pool = new ObjectPoolingBehaviour<Square>(_square,_poolCount,transform);
        RandomizeSquares();
    }

    private void RandomizeSquares()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var square = transform.GetChild(i).GetComponent<Square>();
            square.transform.position = new Vector3(Random.Range(-14, 14), Random.Range(-6, 7), 0);
            square.StartAfterPool();
        }
    }
}
