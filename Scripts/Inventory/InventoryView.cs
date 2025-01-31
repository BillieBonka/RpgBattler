using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class InventoryView : MonoBehaviour
{
    InventoryPresenter presenter;
    InventoryModel inventoryModel;
    [SerializeField] GameObject panel;
    [SerializeField] Sprite slot;
    public Image[] icons;
    [Inject]
    void Construct(InventoryModel inventoryModel, InventoryPresenter presenter){
        this.inventoryModel = inventoryModel;
        this.presenter = presenter;
    }
    void Awake(){
        icons = panel.GetComponentsInChildren<Image>().Skip(1).ToArray();
        inventoryModel.inventoryChanged+=UpdateInventory;
        inventoryModel.player.onLeftHandWeaponChanged+=UpdateWeaponSlots;
    }
    void UpdateWeaponSlots(){
        
    }
    public void UpdateInventory(List<Item> inventory)
    {
        int count = 0;
        foreach(Image icon in icons){
            icon.sprite = slot;
        }
        foreach(Item item in inventory){
            if(item.icon!=null){
                icons[count].sprite = item.icon;
            }
            count++;
        }
    }
    public void OnSlotClick(int number){
        presenter.OnSlotClick(number);
    }
    void OnDestroy(){
        inventoryModel.inventoryChanged-=UpdateInventory;
        inventoryModel.player.onLeftHandWeaponChanged-=UpdateWeaponSlots;
    }
}
