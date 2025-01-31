using UnityEngine;
using Zenject;

public class EncounterInstaller : MonoInstaller
{
    [SerializeField] EnemySpawner enemySpawnerPrefab;
    public GameObject enemyPrefab;
    public override void InstallBindings()
    {
        Container.BindFactory<EnemyData,Enemy, Enemy.Factory>().FromComponentInNewPrefab(enemyPrefab);
        //Container.Bind<EnemiesConfig>().FromInstance(LocationGenerator.instance.GetEnemiesConfig()).AsSingle().NonLazy();
        EnemySpawner enemySpawner = Container.InstantiatePrefabForComponent<EnemySpawner>(enemySpawnerPrefab,Vector3.zero,Quaternion.identity,null);
        Container.Bind<EnemySpawner>().FromInstance(enemySpawner).AsSingle().NonLazy();
        
        //Container.BindInterfacesAndSelfTo<CombatManager>().FromNew().AsSingle().NonLazy();
        
    }
}