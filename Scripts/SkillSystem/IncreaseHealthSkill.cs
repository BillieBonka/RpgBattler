using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseHealthSkill", menuName = "Scriptable Objects/IncreaseHealthSkill")]
public class IncreaseHealthSkill : Skill
{
    [field:SerializeField] int amount;
    
    public override void Learn(Player player){
        IncreasePlayerHealth(player);
    }
    public override void Unlearn(){

    }
    void IncreasePlayerHealth(Player player){
        player.AddStat(Character.StatType.Health, amount);
    }
}
