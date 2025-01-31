using UnityEngine;
using System.Collections.Generic;
using Zenject;

[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Objects/Attack")]
public class Attack : ScriptableObject
{
    [field: SerializeField] public int Damage {get; set;}
    [field: SerializeField] public float CritChance {get; set;}
    [field: SerializeField] public int StaminaCost {get; set;}
    [field: SerializeField] public float Speed {get; set;}
    [field: SerializeField] public float AttackDelay {get; set;}
    [field: SerializeField] public float CounterAttackPercentage {get; set;}
}