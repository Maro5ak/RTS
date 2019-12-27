using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Material{

    public Wood(){
       this.value = 10;
       this.name = "Wood";
    }

    public override string GetName(){
        return this.name;
    }

    public override int GetValue(){
        return this.value;
    }
}
