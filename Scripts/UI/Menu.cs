using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
public class Menu : MonoBehaviour
{
    [SerializeField]  Weapon weaponToEquip;
    [SerializeField] Item item;
    [SerializeField] InventoryPresenter presenter;
    void Awake()
    {
        presenter.OnLeftHandWeaponSlotEnter(weaponToEquip);
    }
    void Start()
    {
        presenter.OnLeftMouseButtonDown(item);
    }
    [Inject]
    void Construct(InventoryPresenter presenter){
        
        this.presenter = presenter;
    }
    // Update is called once per frame
    void Update()
    {
    }
	public void LoadEncounterScene(){
        SceneManager.LoadScene("EncounterScene");
    }
    public void LoadMapScene(){
        SceneManager.LoadScene("MapScene");
    }
}
