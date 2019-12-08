using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour{

    public delegate void BuildingSelected(Transform building);
    public static event BuildingSelected OnBuildingSelect;

    public delegate void BuildingDeselected();
    public static event BuildingDeselected OnBuildingDeselect;

    public delegate void InventoryUpdate(int value);
    public static event InventoryUpdate OnInventoryUpdate;

    public static void BuildingSelect(Transform building){
        if(OnBuildingSelect != null){
            OnBuildingSelect(building);
        }
    }

    public static void BuildingDeselect(){
        if(OnBuildingDeselect != null){
            OnBuildingDeselect();
        }
    }

    public static void InventoryUpdated(int value){
        if(OnInventoryUpdate != null){
            OnInventoryUpdate(value);
        }
    }

}
