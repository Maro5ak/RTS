using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour, IEnvironment{
    public static Home Instance{get; set;}
    public Vector3 size { get; set; }
    public LayerMask npcLayerMask;

    private List<Materials> materials = new List<Materials>();
    private Collider[] colliders;

    void Start() {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }
        else{
            Instance = this;
        }
    }

    private void Update() {
        colliders = Physics.OverlapSphere(transform.position, 1, npcLayerMask);
        foreach(Collider col in colliders){
            if(col.GetComponent<Peasant>().inventory.Count != 0){
                materials.Add(col.GetComponent<Peasant>().inventory[0]);
                col.GetComponent<Peasant>().ClearInventory();
                col.GetComponent<Peasant>().GetWood();
            }
        }
    }

    public void OnTriggerEnter(Collider col){
        Debug.Log(col.name);
    }

    public void AddToInventory(List<Materials> material){
        foreach(Materials mat in material){
            materials.Add(mat);
        }
    }

    public void GetInventory(){
        foreach(Materials item in materials){
            Debug.Log(item.GetName() + ": " + item.GetValue());
        }
        Debug.Log(materials.Count);
    }

    public void SetSize(Vector3 size){
       this.size = size; 
    }  
}
