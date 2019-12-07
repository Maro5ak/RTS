using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSize : MonoBehaviour{

    public void SetSize(Vector3 size){
        transform.localScale = new Vector3(size.x, transform.localScale.y, size.z);
    }

    void OnTriggerEnter(Collider col){
        EventHandler.HandleCollisionEnter(col);
    }
    void OnTriggerExit(Collider col){
        EventHandler.HandleCollisionExit(col);
    }
}
