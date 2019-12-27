using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Material{
    public Stone(){
       this.value = 10;
       this.name = "Stone";
    }

    public override string GetName(){
        return this.name;
    }

    public override int GetValue(){
        return this.value;
    }
}

