using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour, IEnvironment
{
    public void OnTriggerEnter(Collider col){
        Debug.Log(col.name);
    }
}
