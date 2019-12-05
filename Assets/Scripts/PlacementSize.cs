using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSize : MonoBehaviour{

    void OnTriggerEnter(Collider col){
        EventHandler.HandleCollisionEnter(col);
    }
    void OnTriggerExit(Collider col){
        EventHandler.HandleCollisionExit(col);
    }
}
