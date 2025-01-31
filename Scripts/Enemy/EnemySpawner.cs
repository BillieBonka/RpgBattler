using UnityEngine;
using Zenject;
using System.Collections.Generic;
using System;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    CombatManager combatManager;
    public Enemy currentEnemy;
    Enemy.Factory _enemyFactory;
    public EnemiesConfig enemiesConfig;
    List<GameObject> enemies = new();
    int enemyIndex = 0;
    Enemy.Factory enemyFactory;
    public Action enemyChanged;
    LocationGenerator locGen;
    public EnemyData forestEnemy;
    public EnemyData level1Enemy;
    [Inject]
    public void Construct(Enemy.Factory enemyFactory, LocationGenerator lg/*EnemiesConfig config, Enemy.Factory enemyFactory*/){
        /*this.enemyFactory = enemyFactory;*/
        /* enemiesConfig = config; */
        _enemyFactory = enemyFactory;
        locGen = lg;
    }
    void Awake(){
        /*enemiesConfig.enemies;*/
    }
    void Start()
    {
        SpawnEnemies();
        GetNextEnemy();
    }
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            currentEnemy.SetParryTime();
        }
    }
    public void SpawnEnemies(){
        var locationEnemies = locGen.GetEnemiesConfig().enemies;
        for(int i = 0;i<locationEnemies.Count;i++){
            Enemy enemy = null;
            if(locGen.currentLocation==Location.Locations.Level1){
                enemy = _enemyFactory.Create(level1Enemy);
            }
            else{
                enemy = _enemyFactory.Create(forestEnemy);
            }
            
            enemy.gameObject.SetActive(false);
            enemies.Add(enemy.gameObject);
            //locationEnemies[i], Vector3.zero, Quaternion.identity
        }
        /*var enemy = enemyFactory.Create();*/
        
    }
    public void GetNextEnemy(){
        for(int i = enemyIndex;i <enemies.Count;i++){
            if(enemies[i]!=null && enemies[i].GetComponent<Enemy>().IsAlive()){
                enemies[i].SetActive(true);
                enemies[i].GetComponent<Enemy>().onDeath+=GetNextEnemy;
                currentEnemy = enemies[i].GetComponent<Enemy>();
                enemyChanged?.Invoke();
                break;
            }
            else{
                currentEnemy.GetComponent<Enemy>().onDeath-=GetNextEnemy;
                enemyIndex++;
            }
        }
    }
}