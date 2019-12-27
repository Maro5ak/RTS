using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureUI : MonoBehaviour{

    public RectTransform buildingInfoUI;

    private Transform currentlySelected;
    private RectTransform inventoryInfoUI, unitsInfoUI;
    private Text woodInfo, rockInfo, buildName, unitsInfo;
    private Button someButton;
    private bool toggleBuildingInfoUI, gathering;
    private int woodCount, rocksCount, unitCount;

    private void Start() {
        //Event subscription
        UIEventHandler.OnBuildingSelect += UpdateInfo;
        UIEventHandler.OnBuildingDeselect += ToggleInfoUI;
        UIEventHandler.OnInventoryUpdate += SetInventory;
        UIEventHandler.OnUnitUpdate += UpdateUnits;
        //Assigning
        inventoryInfoUI = buildingInfoUI.Find("Inventory").GetComponent<RectTransform>();
        unitsInfoUI = buildingInfoUI.Find("Units").GetComponent<RectTransform>();
        woodInfo = inventoryInfoUI.Find("WoodInventory").GetComponent<Text>();
        rockInfo = inventoryInfoUI.Find("RockInventory").GetComponent<Text>();
        buildName = buildingInfoUI.Find("BuildName").GetComponent<Text>();
        unitsInfo = unitsInfoUI.Find("UnitValue").GetComponent<Text>();
        someButton = buildingInfoUI.Find("SomeOption").GetComponent<Button>();
        woodCount = 0;
        rocksCount = 0;


        //Other stuff
        toggleBuildingInfoUI = false;
        gathering = false;
        buildingInfoUI.gameObject.SetActive(toggleBuildingInfoUI);

    }

    private void UpdateInfo(Transform building){
        toggleBuildingInfoUI = true;
        buildingInfoUI.gameObject.SetActive(toggleBuildingInfoUI);
        buildName.text = building.name;
        if(building.name == "Home"){
            woodInfo.text = "Wood: " + woodCount;
            rockInfo.text = "Stone: " + rocksCount;
            inventoryInfoUI.gameObject.SetActive(true);
            unitsInfoUI.gameObject.SetActive(false);
        }
        else if(building.tag == "NPC"){
            inventoryInfoUI.gameObject.SetActive(false);
            unitsInfoUI.gameObject.SetActive(false);
            someButton.onClick.AddListener(delegate {Gather(); });
        }
        else{
            unitCount = building.GetComponent<EnvironmentClass>().GetUnits();
            unitsInfo.text = building.GetComponent<EnvironmentClass>().GetMaterial()+ ": " + unitCount;
            inventoryInfoUI.gameObject.SetActive(false);
            unitsInfoUI.gameObject.SetActive(true);
        }
        currentlySelected = building;
    }

    private void SetInventory(List<Material> materials){
        woodCount = 0;
        rocksCount = 0;
        foreach(Material mat in materials){
            switch(mat.GetName()){
                case "Wood":
                    woodCount += mat.GetValue();
                    break;
                case "Stone":
                    rocksCount += mat.GetValue();
                    break;
                default:
                    Debug.Log("No such thing exists");
                    break;
            }
            
        }
        woodInfo.text = "Wood: " + woodCount;
        rockInfo.text = "Stone: " + rocksCount;
    }
    private void UpdateUnits(int units, Transform structure){
        if(currentlySelected.name == structure.name){
            unitCount = units;
            UpdateInfo(structure);
        }
    }

    private void ToggleBuildingInfoUI(){
        toggleBuildingInfoUI = !toggleBuildingInfoUI;
        buildingInfoUI.gameObject.SetActive(toggleBuildingInfoUI);
    }

    private void ToggleInfoUI(){
        if(toggleBuildingInfoUI){
            ToggleBuildingInfoUI();
        }
    }

    private void DebugButton(){
        Debug.Log("pepa");
    }

    private void Gather(){
        gathering = !gathering;
        UIEventHandler.ActionSelected(AIController.Actions.Gather);
    }




}
