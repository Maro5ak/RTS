using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour, IEnvironment{
    public static Home Instance{get; set;}
    public Vector3 size { get; set; }
    public LayerMask npcLayerMask;

    private List<Material> materials = new List<Material>();
    private Collider[] colliders;
    private bool pathReset;
    private Transform newMaterial;

    void Start() {
        //event subs
        EventHandler.OnPathReset += ResetPath;

        //Other
        pathReset = false;
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }
        else{
            Instance = this;
        }
    }

    private void Update() {
        colliders = Physics.OverlapSphere(transform.position, 3f, npcLayerMask);
        foreach(Collider col in colliders){
            if(col.GetComponent<Peasant>().inventory.Count != 0){
                materials.Add(col.GetComponent<Peasant>().inventory[0]);
                col.GetComponent<Peasant>().ClearInventory();
                GetInventory();
                if(pathReset){
                    if(newMaterial == null){
                        Debug.Log("No material left!");
                        col.GetComponent<Peasant>().Stop();
                    }
                    else{
                        StartCoroutine(col.GetComponent<Peasant>().GetMaterial(newMaterial));
                        col.GetComponent<Peasant>().target = newMaterial.name;
                        
                    }
                    pathReset = false;
                   
                }
                else{
                StartCoroutine(col.GetComponent<Peasant>().GetMaterial());
                pathReset = false;
                }
                
            }
            
        }
    }

    public void OnTriggerEnter(Collider col){
        Debug.Log(col.name);
    }

    public void GetInventory(){
        UIEventHandler.InventoryUpdated(materials);
    }

    public void SetSize(Vector3 size){
       this.size = size; 
    }

    private void ResetPath(Transform target){
        newMaterial = target;
        pathReset = true;
        
    }

}
