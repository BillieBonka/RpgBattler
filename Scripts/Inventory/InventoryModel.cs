using UnityEngine;
using System.Collections.Generic;
using System;
using Zenject;
public class InventoryModel : IInitializable
{
    public Inventory inventory;
    public Player player;
    public Action<List<Item>> inventoryChanged;
    
    public InventoryModel(Inventory inventory, Player player){
        this.player = player;
        this.inventory = inventory;
        inventory.inventoryChanged += OnInventoryChanged;
    }
    public void Initialize(){
        
        
    }
    void OnInventoryChanged(){
        inventoryChanged?.Invoke(inventory.inventory);
    }
    
}