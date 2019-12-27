using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClass : EnvironmentClass, IEnvironment{
    public Vector3 size { get; set; }
    public LayerMask npcLayer, environmentLayer;
    


    private Collider[] colliders;
    private Collider[] trees;
    private float timeToGetWood = 2f;
    private Vector3 treePos;
    private int numOfUnits;

    private void Start() {
        numOfUnits = 5;
        treePos = this.transform.position;
    }

    public void OnTriggerEnter(Collider col){
        Debug.Log(col.name);
    }

    void Update(){
        if(numOfUnits == 0){
            ResetPath();
            Destroy(this.gameObject);
        }
        timeToGetWood = timeToGetWood >= 0 ? timeToGetWood : 2f;
        colliders = Physics.OverlapSphere(transform.position, 1, npcLayer);
        foreach(Collider col in colliders){
            if(this.transform.name == col.GetComponent<Peasant>().target){
                timeToGetWood -= Time.deltaTime;
                if(timeToGetWood <= 0){
                    col.GetComponent<Peasant>().inventory.Add(new Wood());
                    StartCoroutine(col.GetComponent<Peasant>().GetBackHome());
                    numOfUnits--;
                    UIEventHandler.UnitGathered(numOfUnits*10, transform);
                }
            }
        }
    
        
    }

    public void SetSize(Vector3 size){
       this.size = size; 
    }  

    public override int GetUnits(){
        return numOfUnits * 10;
    }

    public override string GetMaterial(){
        return "Wood";
    }

    internal void ResetPath(){
        trees = Physics.OverlapSphere(transform.position, 8, environmentLayer);
        float minDistance = Mathf.Infinity;
        Transform closestTree = null;
        foreach(Collider tree in trees){
            if(tree.transform.tag != "Rock"){
                if(tree.transform != transform){
                    float distance = Vector3.Distance(tree.transform.position, treePos);
                    if(distance < minDistance){
                        closestTree = tree.transform;
                        minDistance = distance;
                    }
                }
            }   
        }
        Debug.Log("reset");
        EventHandler.ResetPath(closestTree);
    }
}
