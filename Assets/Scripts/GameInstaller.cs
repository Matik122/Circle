using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{ 
    [SerializeField] private InterfaceEncounters _click;
    public override void InstallBindings()
    {
        Container.Bind<InterfaceEncounters>().FromInstance(_click).AsSingle().NonLazy();
    }
}
