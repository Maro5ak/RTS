using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockClass : EnvironmentClass, IEnvironment{
    public Vector3 size { get; set; }
    public LayerMask npcLayer, environmentLayer;
    

    private Collider[] colliders;
    private Collider[] rocks;
    private float timeToGetRocks = 3f;
    private Vector3 rockPos;
    private int numOfUnits;

    private void Start() {
        numOfUnits = 1;
        rockPos = this.transform.position;
    }

    public void OnTriggerEnter(Collider col){
        Debug.Log(col.name);
    }

    void Update(){
        if(numOfUnits == 0){
            ResetPath();
            Destroy(this.gameObject);
            
        }
        timeToGetRocks = timeToGetRocks >= 0 ? timeToGetRocks : 2f;
        colliders = Physics.OverlapSphere(transform.position, 1, npcLayer);
        foreach(Collider col in colliders){
            if(this.transform.name == col.GetComponent<Peasant>().target){
                timeToGetRocks -= Time.deltaTime;
                if(timeToGetRocks <= 0){
                    col.GetComponent<Peasant>().inventory.Add(new Stone());
                    numOfUnits--;
                    StartCoroutine(col.GetComponent<Peasant>().GetBackHome());
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
        return "Stone";
    }

    internal void ResetPath(){
        rocks = Physics.OverlapSphere(transform.position, 8, environmentLayer);
        float minDistance = Mathf.Infinity;
        Transform closestRock = null;
        foreach(Collider rock in rocks){
            if(rock.transform.tag != "Tree"){
                if(rock.transform != transform){
                    float distance = Vector3.Distance(rock.transform.position, rockPos);
                    if(distance < minDistance){
                        closestRock = rock.transform;
                        minDistance = distance;
                    }
                }
            }
             
        }
        Debug.Log("reset");
        EventHandler.ResetPath(closestRock);
    }
}
