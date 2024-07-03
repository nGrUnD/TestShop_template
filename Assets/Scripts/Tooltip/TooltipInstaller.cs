using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TooltipInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<TooltipView>().FromComponentInHierarchy().AsSingle();
    }
}