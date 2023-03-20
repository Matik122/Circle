using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{ 
    [SerializeField] private Click _click;
    public override void InstallBindings()
    {
        Container.Bind<Click>().FromInstance(_click).AsSingle().NonLazy();
    }
}
