using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Materials{
   protected int value;
   protected string name;

   public abstract string GetName();
   public abstract int GetValue();
}
