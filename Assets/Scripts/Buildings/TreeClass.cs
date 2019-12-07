using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClass : MonoBehaviour, IEnvironment{
    public Vector3 size { get; set; }
    public LayerMask npcLayer;

    private Collider[] colliders;
    private float timeToGetWood = 2f;

    public void OnTriggerEnter(Collider col){
        Debug.Log(col.name);
    }

    void Update(){
        timeToGetWood = timeToGetWood >= 0 ? timeToGetWood : 2f;
        colliders = Physics.OverlapSphere(transform.position, 1, npcLayer);
        if(colliders.Length >= 1){
            if(this.transform.name == AIController.target){
                timeToGetWood -= Time.deltaTime;
                if(timeToGetWood <= 0){
                colliders[0].GetComponent<Peasant>().inventory.Add(new Wood());
                colliders[0].GetComponent<Peasant>().GetBackHome();
                }
            }
        }
    }

    public void SetSize(Vector3 size){
       this.size = size; 
    }  
}
