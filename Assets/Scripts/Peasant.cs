using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Peasant : MonoBehaviour{

    [HideInInspector]
    public bool gotWood;

    Transform home;
    NavMeshAgent agent;



    void Start(){
        gotWood = false;
        home = GameObject.Find("Home").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }


    public void GetWood(Transform woodLocation){
        agent.SetDestination(woodLocation.position);
        agent.stoppingDistance = 0;
    }

    void Update(){
        if(gotWood)
        GetBackHome();
    }

    private void GetBackHome(){
        agent.SetDestination(home.position);
        agent.stoppingDistance = 2;
        Home.Instance.AddToInventory(new Wood());
        gotWood = false;
    }
}
