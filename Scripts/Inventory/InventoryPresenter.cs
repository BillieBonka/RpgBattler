using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryPresenter
{
    InventoryModel inventoryModel;
    public InventoryPresenter(InventoryModel inventoryModel){
        this.inventoryModel = inventoryModel;
    }
    public void OnLeftMouseButtonDown(Item item){
        inventoryModel.inventory.AddItem(item);
    }
    public void OnLeftHandWeaponSlotEnter(Weapon leftHandWeapon){
        Debug.Log(leftHandWeapon.attack.Damage);
        inventoryModel.player.EquipWeapon(leftHandWeapon);
    }
    public void OnSlotClick(int slotNumber){
        var item = inventoryModel.inventory.GetItemBySlotPosition(slotNumber);
        if(item as Weapon){
            OnLeftHandWeaponSlotEnter((Weapon)item);
        }
        if(item as Food){
            ((Food)item).Use(inventoryModel.player);
            inventoryModel.inventory.RemoveItem(item);
        }
    }
}