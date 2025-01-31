using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class InventorySlot : MonoBehaviour
{
    public int number;
    InventoryPresenter presenter;
    [Inject]
    void Construct(InventoryPresenter presenter){
        this.presenter = presenter;
    }
    void Awake(){
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnSlotClick(){
        presenter.OnSlotClick(number);
    }
}
