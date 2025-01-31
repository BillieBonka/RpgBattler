using UnityEngine;
using System.Collections.Generic;
using Zenject;

public class CombatManager:MonoBehaviour
{
    Player player;
    Enemy enemy;
    EnemySpawner enemySpawner;
    [Inject]
    public void Construct(Player player, EnemySpawner enemySpawner){
        this.player = player;
        this.enemySpawner = enemySpawner;
    }
    public void IInitialize(){

    }
    void Awake(){
        enemySpawner.enemyChanged += BeginCombat;
    }
    void BeginCombat(){
        enemy = enemySpawner.currentEnemy;
        if(player.IsAlive() && enemy!= null){
            player.BeginAttack(enemy);
            enemy.BeginAttack(player);
        }
    }
}