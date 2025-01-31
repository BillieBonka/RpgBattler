using UnityEngine;
using System.Collections.Generic;
using System;
using Zenject;
public class Inventory : IInitializable
{
    public Action inventoryChanged;
    List<Item> items = new List<Item>(10);
    public List<Item> inventory{
        get{
            return items;
        }
    }
    public Inventory(){
    }
    public void Initialize(){
    }
    public bool AddItem(Item itemToAdd){
        if(items.Count == items.Capacity){
            return false;
        }
        items.Add(itemToAdd);
        inventoryChanged();
        return true;
    }
    public bool AddItems(List<Item> itemsToAdd){
        if(itemsToAdd.Count>items.Capacity-items.Count){
            return false;
        }
        if(items.Count == items.Capacity){
            return false;
        }
        items.AddRange(itemsToAdd);
        inventoryChanged();
        return true;
    }
    public void RemoveItem(Item i){
        items.Remove(i);
        inventoryChanged();
    }
    public Item FindItemById(int id){ 
        return items.Find(x => x.id == id);
    }
    public Item GetItemBySlotPosition(int x){ 
        return items[x];
    }
    void SetWeaponToLeftHandWeaponSlot(Weapon weapon){

    }
}
