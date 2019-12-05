using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour, IEnvironment{
    public static Home Instance{get; set;}

    private List<Materials> materials = new List<Materials>();

    void Start() {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }
        else{
            Instance = this;
        }
    }


    public void OnTriggerEnter(Collider col){
        Debug.Log(col.name);
    }

    public void AddToInventory(Materials material){
        materials.Add(material);
    }

    public void GetInventory(){
        foreach(Materials item in materials){
            Debug.Log(item.GetName() + ": " + item.GetValue());
        }
        Debug.Log(materials.Count);
    }
}
