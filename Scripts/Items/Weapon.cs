using UnityEngine;
using UnityEngine.UI;
using Zenject;
[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class Weapon : Item
{     
    public Attack attack;
    public void GenerateDamage(){
        attack = Instantiate(attack);
        attack.Damage = Random.Range(1,10);
    }
}
