using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] Player playerPrefab;
    [SerializeField] LocationGenerator locGenPref;
    public override void InstallBindings()
    {
        LocationGenerator locGen = Container.InstantiatePrefabForComponent<LocationGenerator>(locGenPref,Vector3.zero,Quaternion.identity,null);
        Container.Bind<LocationGenerator>().FromInstance(locGen).AsSingle().NonLazy();
        Player playerInstance = Container.InstantiatePrefabForComponent<Player>(playerPrefab,Vector3.zero,Quaternion.identity,null);
        Container.Bind<Player>().FromInstance(playerInstance).AsSingle().NonLazy();
        BindInventory();
    }
    void BindInventory(){
        Container.BindInterfacesAndSelfTo<Inventory>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InventoryModel>().FromNew().AsSingle().NonLazy();
        Container.Bind<InventoryPresenter>().FromNew().AsSingle().NonLazy();
    }
}