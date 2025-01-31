using UnityEngine;
using System.Collections.Generic;
using System;

public class LocationGenerator : MonoBehaviour
{
    public Location.Locations currentLocation;
    [SerializeField] List<EnemiesConfig> locationConfigs;
    public static LocationGenerator instance;
    void Awake(){
        /* if(!instance){
            instance = GetComponent<LocationGenerator>();
        }
        Debug.Log(instance.name); */
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetCurrentLocation(Location.Locations location){
        currentLocation = location;
    }
    public EnemiesConfig GetEnemiesConfig(){
        return locationConfigs.Find(x=>x.enemiesLocation == currentLocation);
    }
}