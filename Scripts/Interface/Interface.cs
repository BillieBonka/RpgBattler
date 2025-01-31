using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class Interface : MonoBehaviour
{
    [SerializeField] Slider healthBarPrefab;
    [SerializeField] Slider staminaBarPrefab;
    [SerializeField] Slider manaBarPrefab;
    Slider healthBar;
    Slider staminaBar;
    Slider manaBar;
    public static Interface instance;
    public Player player;
    [Inject]
    void Construct(Player player){
        this.player = player;
    }
    void Awake()
    {
        player.onHealthChanged += UpdateHealthBar;
        healthBar = Instantiate(healthBarPrefab,GameObject.Find("Canvas").transform);
        healthBar.value = healthBar.maxValue;
        player.onStaminaChanged += UpdateStaminaBar;
        staminaBar = Instantiate(staminaBarPrefab,GameObject.Find("Canvas").transform);
        staminaBar.value = staminaBar.maxValue;
        player.onManaChanged += UpdateManaBar;
        manaBar = Instantiate(manaBarPrefab,GameObject.Find("Canvas").transform);
        manaBar.value = manaBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateHealthBar(int health, int maxHealth){
        Debug.Log(healthBar.value + "HealthBar");
        healthBar.value = (float)health/maxHealth*100f;
    }
    void UpdateStaminaBar(int stamina, int maxStamina){
        staminaBar.value = (float)stamina/maxStamina*100f;
    }
    void UpdateManaBar(int mana, int maxMana){
        manaBar.value = (float)mana/maxMana*100f;
    }
}
