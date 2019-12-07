using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CylinderBuilding : MonoBehaviour, IEnvironment{

    public Vector3 size { get; set; }


    private NavMeshObstacle navMeshObstacle;
    private void Start() {
        navMeshObstacle = GetComponent<NavMeshObstacle>();
    }
    public void OnTriggerEnter(Collider col){
        Debug.Log(col.name);
    }

    public void SetSize(Vector3 size){
       this.size = size; 
    }  
}
