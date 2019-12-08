using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeBaseUI : MonoBehaviour{

    public RectTransform buildingInfoUI;

    private Text inventoryInfo, buildName;
    private Button someButton;
    private bool toggleBuildingInfoUI;
    private int inventorySize;

    private void Start() {
        //Event subscription
        UIEventHandler.OnBuildingSelect += UpdateInfo;
        UIEventHandler.OnBuildingDeselect += ToggleBuildingInfoUI;
        UIEventHandler.OnInventoryUpdate += SetInventory;
        //Assigning
        inventoryInfo = buildingInfoUI.Find("Inventory").GetComponentInChildren<Text>();
        buildName = buildingInfoUI.Find("BuildName").GetComponent<Text>();
        someButton = buildingInfoUI.Find("SomeOption").GetComponent<Button>();
        //Button setup
        someButton.onClick.AddListener(delegate {DebugButton(); });



        //Other stuff
        toggleBuildingInfoUI = false;
        buildingInfoUI.gameObject.SetActive(toggleBuildingInfoUI);
    }

    private void UpdateInfo(Transform building){
        ToggleBuildingInfoUI();
        buildName.text = building.name;
        inventoryInfo.text = "Wood Capacity: " + inventorySize;
    }

    internal void SetInventory(int value){
        inventorySize = value;
        inventoryInfo.text = "Wood Capacity: " + value;
    }

    private void ToggleBuildingInfoUI(){
        toggleBuildingInfoUI = !toggleBuildingInfoUI;
        buildingInfoUI.gameObject.SetActive(toggleBuildingInfoUI);
       
    }

    private void DebugButton(){
        Debug.Log("pepa");
    }




}
