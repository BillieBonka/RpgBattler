using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{   
    [field:SerializeField] public int Health {get; private set;}
    [field:SerializeField] public int MaxHealth {get; private set;}
    [field:SerializeField] public Weapon EnemyWeapon {get; private set;}
}