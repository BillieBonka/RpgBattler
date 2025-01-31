using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Character : MonoBehaviour
{
    public enum StatType{
        Health,
        Stamina,
        Mana
    }
    protected int health;
    public int maxHealth;
    protected int stamina;
    public int maxStamina;
    [SerializeField] protected int staminaRegenValue;
    [SerializeField] protected float staminaRegenRate;
    [SerializeField] protected int healthRegenValue;
    [SerializeField] protected float healthRegenRate;
    protected int mana;
    public int maxMana;
    float nextAttackTime;
    bool isAlive = true;
    Weapon leftWeapon;
    public Action<int,int> onHealthChanged;
    public Action<int,int> onStaminaChanged;
    public Action<int,int> onManaChanged;
    protected float attackTime;
    bool parryFlag;
    
    public Weapon leftHandWeapon{
        set{
            onLeftHandWeaponChanged?.Invoke();
            leftWeapon= value;
        }
        get{
            return leftWeapon;
        }
    }
    public Weapon rightHandWeapon;
    public Action onLeftHandWeaponChanged;
    public Action onDeath;
    
    protected virtual void Initialize(){
        
        health = maxHealth;
        stamina = maxStamina;
    }
    protected virtual void Start(){
        StartCoroutine(RestoreStat(StatType.Stamina,staminaRegenValue,staminaRegenRate));
        StartCoroutine(RestoreStat(StatType.Health,healthRegenValue,healthRegenRate));
    }
    protected virtual void Update(){
        if(parryFlag == false && attackTime<leftWeapon.attack.Speed){
            attackTime += Time.deltaTime;
        }
    }
    public void EquipWeapon(Weapon weapon){
        leftHandWeapon = weapon;
    }
    public void BeginAttack(Character target){
        if(stamina>0){
            StartCoroutine(Attack(target));
        }
    }
    public IEnumerator Attack(Character target){
        while(target!= null && target.IsAlive()){
            if(stamina<=0){
                yield return null;
                continue;
            }
            attackTime = 0;
            parryFlag = false;
            yield return new WaitForSeconds(leftWeapon.attack.Speed);
            if(parryFlag == true){
                continue;
            }
            ReduceStat(StatType.Stamina,leftWeapon.attack.StaminaCost);
            target.ReduceStat(StatType.Health, leftWeapon.attack.Damage);
            Debug.Log(stamina +"StamRed");
        }
    }
    public IEnumerator RestoreStat(StatType stat,int amount, float rate){
        while(true){
            yield return new WaitForSeconds(rate);
            AddStat(stat,amount);
        }
    }
    public virtual void AddStat(StatType stat,int amount){
        if(stat == StatType.Health){
            health+=amount;
            onHealthChanged?.Invoke(health,maxHealth);
        }
        if(stat == StatType.Stamina){
            stamina+=amount;
            onStaminaChanged?.Invoke(stamina,maxStamina);
        }
        if(stat == StatType.Mana){
            mana+=amount;
            onManaChanged?.Invoke(mana,maxMana);
        }
    }
    public virtual void ReduceStat(StatType stat,int amount){
        if(stat == StatType.Health){
            health-=amount;
            Debug.Log(onHealthChanged + "Hpevent");
            onHealthChanged?.Invoke(health,maxHealth);
        }
        if(stat == StatType.Stamina){
            stamina-=amount;
            onStaminaChanged?.Invoke(stamina,maxStamina);
        }
        if(stat == StatType.Mana){
            mana-=amount;
            onManaChanged?.Invoke(mana,maxMana);
        }
        if(health<=0){
            Kill();
        }
    }
    public virtual void Kill(){
        isAlive = false;
        StopAllCoroutines();
        onDeath?.Invoke();
    }
    protected virtual void OnDeath(){

    }
    public bool IsAlive(){
        return isAlive;
    }
    public void SetParryTime(){
        if(parryFlag==false && ((leftWeapon.attack.Speed-attackTime)<leftWeapon.attack.Speed*leftWeapon.attack.CounterAttackPercentage)){
            parryFlag = true;
        }
        
    }
}
