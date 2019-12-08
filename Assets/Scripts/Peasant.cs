using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Peasant : MonoBehaviour{
    Transform home;
    NavMeshAgent agent;
    public List<Materials> inventory = new List<Materials>();
    
    Vector3 treeLocation;



    void Start(){

        home = GameObject.Find("Home").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }


    public void GetWood(Transform woodLocation){
        treeLocation = woodLocation.position;
        agent.SetDestination(treeLocation);
        agent.stoppingDistance = 0;
    }

    public void GetWood(){
        agent.SetDestination(treeLocation);
        agent.stoppingDistance = 0;
    }
    public void GetBackHome(){
        agent.SetDestination(home.position);
        agent.stoppingDistance = 2;
        
    }

    public void ClearInventory(){
        inventory.Clear();
    }

    public void Stop(){
        agent.SetDestination(transform.position);
    }
}
