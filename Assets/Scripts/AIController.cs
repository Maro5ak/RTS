using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour{

    public static string target;
    public Button setRoutine;
    public Transform tree;
    public LayerMask npcMask, environmentMask;

    private Peasant peasant;
    private bool npcSelected, routineActive;

    void Start(){
        npcSelected = false;

        setRoutine.onClick.AddListener(delegate {SetRoutine(); });
        setRoutine.gameObject.SetActive(routineActive);
    }

    void Update(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, npcMask)){ 
            if(Input.GetMouseButtonDown(0)){
                Debug.Log("Selected " + hitInfo.collider.name);
                peasant = GameObject.Find(hitInfo.collider.name).GetComponent<Peasant>();
                npcSelected = !npcSelected;
            }
        }
        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, environmentMask)){
            if(Input.GetMouseButtonDown(0) && npcSelected){
                Debug.Log("Going for " + hitInfo.collider.name);
                npcSelected = !npcSelected;
                target = hitInfo.collider.name;
                tree = hitInfo.collider.transform;
                ToggleRoutineButton();
                setRoutine.gameObject.SetActive(routineActive);
            }

        }
    }

    void SetRoutine(){
        peasant.GetWood(tree);
        ToggleRoutineButton();
        setRoutine.gameObject.SetActive(routineActive);

    }

    internal void ToggleRoutineButton(){
        routineActive = !routineActive;
    }




}
