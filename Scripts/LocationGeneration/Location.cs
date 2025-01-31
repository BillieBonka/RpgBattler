using UnityEngine;
using System.Collections.Generic;
using System;
using Zenject;

public class Location : MonoBehaviour
{
    public enum Locations{
        Level1,
        Forest
    }
    LocationGenerator locationGenerator;
    public Locations location;
    [Inject]
    void Construct(LocationGenerator locationGen){
        locationGenerator = locationGen;
    }
    public void OnClick(){
        locationGenerator.SetCurrentLocation(location);
    }
}