using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class GameInstaller : MonoInstaller
{ 
    [SerializeField] private InterfaceEncounters _interface;
    [Inject] private DiContainer _diContainer;
    
    public override void InstallBindings()
    {
        DIContainerRef.Container = _diContainer;
        Container.Bind<InterfaceEncounters>().FromInstance(_interface).AsSingle().NonLazy();
    }
}
