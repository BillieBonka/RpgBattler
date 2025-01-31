using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "EnemiesConfig", menuName = "Scriptable Objects/EnemiesConfig")]
public class EnemiesConfig: ScriptableObject
{   
    public Location.Locations enemiesLocation;
    public List<GameObject> enemies;
}