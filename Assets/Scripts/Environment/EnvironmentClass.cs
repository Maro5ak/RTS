using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentClass : MonoBehaviour{
    public virtual int GetUnits(){
        return 0;
    }

    public virtual string GetMaterial(){
        return null;
    }
}
