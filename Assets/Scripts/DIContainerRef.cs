using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public static class DIContainerRef 
{
    private static DiContainer _container;

    public static DiContainer Container
    {
        get => _container;
        set => _container ??= value;
    }
}
