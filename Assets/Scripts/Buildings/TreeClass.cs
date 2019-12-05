using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClass : MonoBehaviour, IEnvironment{

    public LayerMask npcLayer;

    private Collider[] colliders;

    public void OnTriggerEnter(Collider col){
        Debug.Log(col.name);
    }

    void Update(){
        colliders = Physics.OverlapSphere(transform.position, 1, npcLayer);
        if(colliders.Length >= 1){
            if(this.transform.name == AIController.target)
            colliders[0].GetComponent<Peasant>().gotWood = true;
        }

        
    }
}
