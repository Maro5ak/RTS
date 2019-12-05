using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClass : MonoBehaviour, IEnvironment{

    public LayerMask npcLayer;

    private Collider[] colliders;
    private float timeToGetWood;

    public void OnTriggerEnter(Collider col){
        Debug.Log(col.name);
    }
    void Start(){
        timeToGetWood = 2f;
    }

    void Update(){
        colliders = Physics.OverlapSphere(transform.position, 1, npcLayer);
        if(colliders.Length >= 1){
            if(this.transform.name == AIController.target){
                timeToGetWood -= Time.deltaTime;
                if(timeToGetWood <= 0)
                colliders[0].GetComponent<Peasant>().gotWood = true;
            }
        }
    }
}
