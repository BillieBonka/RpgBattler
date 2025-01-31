using UnityEngine;
using UnityEngine.UI;
using System;
using Zenject;
using System.Linq;

public class Enemy : Character
{
    [SerializeField] LootData enemyDrop;
    Inventory inventory;
    [SerializeField] Slider healthBar;
    [SerializeField] Slider staminaBar;
    [SerializeField] Slider attackBar;
    
    EnemyData enemyData;
    [Inject]
    void Construct(Inventory inventory,EnemyData enemyData){
        this.inventory = inventory;
        this.enemyData = enemyData;
    }
    protected override void Initialize(){
        health = enemyData.Health;
        maxHealth = enemyData.MaxHealth;

        base.Initialize();
    }
    void Awake(){
        Initialize();
        EquipWeapon(enemyData.EnemyWeapon);
        var sliders = GetComponentsInChildren<Slider>();
        healthBar = sliders.Where(x =>x.name=="HealthBar").ToArray()[0];
        staminaBar = sliders.Where(x =>x.name=="StaminaBar").ToArray()[0];
        attackBar = sliders.Where(x =>x.name=="AttackBar").ToArray()[0];
    }
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update(){
        healthBar.value = (float)health/maxHealth*100f;
        attackBar.value = attackTime/leftHandWeapon.attack.Speed*100f;
        staminaBar.value = (float)stamina/maxStamina*100f;
        base.Update();
    }
    public override void Kill(){
        base.Kill();
        DropItems(enemyDrop);
        Destroy(gameObject);
    }
    void OnDestroy(){
        onDeath = null;
    }
    void DropItems(LootData lootData){
        foreach(var i in lootData.items){
            if(i as Weapon){
                Weapon w = Instantiate((Weapon)i);
                w.GenerateDamage();
                inventory.AddItem(w);
                continue;
            }
            inventory.AddItem(i);
        }
    }
    public class Factory : PlaceholderFactory<EnemyData, Enemy>
    {
    }
}
