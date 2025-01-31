using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class Player : Character
{
    [SerializeField] int experience;
    [SerializeField]  int level;
    [SerializeField] IncreaseHealthSkill skill;


    void Awake(){
        Initialize();
    }
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            skill.Learn(this);
        }
        base.Update();
    }
 
    public void AddExp(int amount){
        experience += amount;
        GrantLevel();
    }
    public void GrantLevel(){
        if(experience >= 100){
            level++;
        }
    }
}