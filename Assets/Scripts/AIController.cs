using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour{

    public enum Actions {Gather, Attack}

    public static string target;
    
    public Transform material;
    public Image imageToShow;
    public LayerMask npcMask, environmentMask;

    private Peasant peasant;
    private Vector3 offsetMousePos;
    private bool npcSelected, routineActive, actionActive;

    void Start(){
        npcSelected = false;
        imageToShow.gameObject.SetActive(false);
        UIEventHandler.OnActionSelected += ShowActionUI;
    }

    void Update(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, npcMask)){ 
            if(Input.GetMouseButtonDown(0)){
                Debug.Log("Selected " + hitInfo.collider.name);
                peasant = GameObject.Find(hitInfo.collider.name).GetComponent<Peasant>();
                npcSelected = !npcSelected;
                UIEventHandler.BuildingSelect(hitInfo.transform);
            }
        }
        if(actionActive){
            offsetMousePos = new Vector3(Input.mousePosition.x + 45f, Input.mousePosition.y - 45f, Input.mousePosition.z);
            imageToShow.transform.position = offsetMousePos;
            if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, environmentMask)){
                if(Input.GetMouseButtonDown(0) && npcSelected){
                    Debug.Log("Going for " + hitInfo.collider.name);
                    npcSelected = !npcSelected;
                    target = hitInfo.collider.name;
                    material = hitInfo.collider.transform;
                    SetRoutine();
                    imageToShow.gameObject.SetActive(false);
                    actionActive = false;
                }
            }
            if(Input.GetMouseButtonDown(1)){
                    imageToShow.gameObject.SetActive(false);
                    actionActive = false;
                    UIEventHandler.BuildingDeselect();
                }
        }
    }

    void SetRoutine(){
        StartCoroutine(peasant.GetMaterial(material));
        peasant.target = target;


    }

    private void ToggleRoutineButton(){
        routineActive = !routineActive;
    }

    private void ShowActionUI(Actions action){
        switch(action){
            case Actions.Gather:
                imageToShow.gameObject.SetActive(true);
                imageToShow.sprite = Resources.Load<Sprite>("Icons/axe");
                actionActive = true;
                break;
            case Actions.Attack:
                break;
            default:
                break;
        }
    }




}
