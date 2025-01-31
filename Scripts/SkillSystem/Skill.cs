using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Scriptable Objects/Skill")]
public class Skill : ScriptableObject
{
    [field:SerializeField] public int SkillPointsCost {get; private set;}
    [field:SerializeField] bool isUnlocked;
    [field:SerializeField] bool isLearned;
    public void Unlock() => isUnlocked = true;
    public void Lock() => isUnlocked = false;
    public virtual void Learn(Player player) => isLearned = true;
    public virtual void Unlearn() => isLearned = false;
}
