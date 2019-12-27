using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Peasant : MonoBehaviour{
    public string target;
    Transform home;
    NavMeshAgent agent;
    public List<Material> inventory = new List<Material>();
    
    Vector3 matLocation;



    void Start(){
        home = GameObject.Find("Home").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }


    public IEnumerator GetMaterial(Transform materialLocation){
        matLocation = materialLocation.position;
        agent.SetDestination(matLocation);
        agent.stoppingDistance = 0;
        yield break;
    }

    public IEnumerator GetMaterial(){
        agent.SetDestination(matLocation);
        agent.stoppingDistance = 0;
        yield break;
    }
    public IEnumerator GetBackHome(){
        agent.SetDestination(home.position);
        agent.stoppingDistance = 3;
        yield break;
        
    }

    public void ClearInventory(){
        inventory.Clear();
    }

    public void Stop(){
        agent.SetDestination(transform.position);
    }

    
}
