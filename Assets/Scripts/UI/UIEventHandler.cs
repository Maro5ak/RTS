using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour{

    public delegate void BuildingSelected(Transform building);
    public static event BuildingSelected OnBuildingSelect;

    public delegate void BuildingDeselected();
    public static event BuildingDeselected OnBuildingDeselect;

    public delegate void InventoryUpdate(List<Material> materials);
    public static event InventoryUpdate OnInventoryUpdate;

    public delegate void UnitUpdate(int units, Transform transform);
    public static event UnitUpdate OnUnitUpdate;

    public delegate void ActionSelect(AIController.Actions action);
    public static event ActionSelect OnActionSelected;

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

    public static void InventoryUpdated(List<Material> materials){
        if(OnInventoryUpdate != null){
            OnInventoryUpdate(materials);
        }
    }

    public static void UnitGathered(int units, Transform transform){
        if(OnUnitUpdate != null){
            OnUnitUpdate(units, transform);
        }
    }

    public static void ActionSelected(AIController.Actions action){
        if(OnActionSelected != null){
            OnActionSelected(action);
        }
    }

}
