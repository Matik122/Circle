using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingBehaviour<T> where T : MonoBehaviour
{
    public T prefab { get;}
    public Transform container;
    
    private List<T> _poolList = new();

    public ObjectPoolingBehaviour(T prefab, int poolCount, Transform container)
    {
        this.prefab = prefab;
        this.container = container;
        InstantiatePool(poolCount);
    }

    private void InstantiatePool(int poolCount)
    {
        for (var i = 0; i < poolCount; i++)
        {
            CreatePoolObject();
        }
    }

    private T CreatePoolObject(bool isActive = false)
    {
        var poolObject = DIContainerRef.Container.InstantiatePrefab(prefab, container).GetComponent<T>();
        poolObject.gameObject.SetActive(isActive);
        _poolList.Add(poolObject);
        return poolObject;
    }


    public bool IsElementFree(out T element)
    {
        foreach (var freeElement in _poolList)
        {
            if (!freeElement.gameObject.activeInHierarchy)
            {
                element = freeElement;
                freeElement.gameObject.SetActive(true);
                return true;
            }
        }
        
        element = null;
        return false;
    }
}