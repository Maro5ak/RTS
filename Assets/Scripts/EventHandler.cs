using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour{
    public delegate void CollisionHandler(Collider col);
    public static event CollisionHandler OnCollisionWithScenery;
    public static event CollisionHandler OnCollisionWithSceneryExit;


    public static void HandleCollisionEnter(Collider col){
        if(OnCollisionWithScenery != null){
            OnCollisionWithScenery(col);
        }
    }
    public static void HandleCollisionExit(Collider col){
        if(OnCollisionWithSceneryExit != null){
            OnCollisionWithSceneryExit(col);
        }
    }
}
