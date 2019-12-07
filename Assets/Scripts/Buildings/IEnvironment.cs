using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnvironment {
    void SetSize(Vector3 size);
    void OnTriggerEnter(Collider col);
}
