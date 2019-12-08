using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClass : MonoBehaviour, IEnvironment{
    public Vector3 size { get; set; }
    public LayerMask npcLayer, environmentLayer;
    
    public int LifeTime{get; set;}

    private Collider[] colliders;
    private Collider[] trees;
    private float timeToGetWood = 2f;
    private Vector3 treePos;

    private void Start() {
        LifeTime = 1;
        treePos = this.transform.position;
    }

    public void OnTriggerEnter(Collider col){
        Debug.Log(col.name);
    }

    void Update(){
        if(LifeTime == 0){
            ResetPath();
            Destroy(this.gameObject);
            
        }
        timeToGetWood = timeToGetWood >= 0 ? timeToGetWood : 2f;
        colliders = Physics.OverlapSphere(transform.position, 1, npcLayer);
        if(colliders.Length >= 1){
            if(this.transform.name == AIController.target){
                timeToGetWood -= Time.deltaTime;
                if(timeToGetWood <= 0){
                    colliders[0].GetComponent<Peasant>().inventory.Add(new Wood());
                    LifeTime--;
                    colliders[0].GetComponent<Peasant>().GetBackHome();
                }
            }
        }
        
    }

    public void SetSize(Vector3 size){
       this.size = size; 
    }  

    internal void ResetPath(){
        trees = Physics.OverlapSphere(transform.position, 8, environmentLayer);
        float minDistance = Mathf.Infinity;
        Transform closestTree = null;
        foreach(Collider tree in trees){
           if(tree.transform != transform){
                float distance = Vector3.Distance(tree.transform.position, treePos);
                if(distance < minDistance){
                    closestTree = tree.transform;
                    minDistance = distance;
                }
           }
             
        }
        Debug.Log("reset");
        EventHandler.ResetPath(closestTree);
    }
}
