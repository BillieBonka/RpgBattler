using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Food", menuName = "Scriptable Objects/Food")]
public class Food : Item, IUsable
{
    [SerializeField] int restoreHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Use(Character character){
        character.AddStat(Character.StatType.Health, restoreHealth);
    }
}
