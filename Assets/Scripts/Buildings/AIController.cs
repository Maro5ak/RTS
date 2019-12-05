using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour{

    public static string target;
    public Button getWood;
    public Transform tree;
    public LayerMask npcMask, environmentMask;

    private Peasant peasant;
    private bool npcSelected;



    void Start(){
        npcSelected = false;
        peasant = GameObject.Find("Peasant").GetComponent<Peasant>();

        getWood.onClick.AddListener(delegate {GetWood(); });
    }

    void Update(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, npcMask)){ 
            if(Input.GetMouseButtonDown(0)){
                Debug.Log("Selected " + hitInfo.collider.name);
                npcSelected = !npcSelected;
            }
        }
        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, environmentMask)){
            if(Input.GetMouseButtonDown(0) && npcSelected){
                Debug.Log("Going for " + hitInfo.collider.name);
                npcSelected = !npcSelected;
                target = hitInfo.collider.name;
                peasant.GetWood(hitInfo.collider.transform); 
            }
        }
    }

    private void GetWood(){
        peasant.GetWood(tree);
    }



}
