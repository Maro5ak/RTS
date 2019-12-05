using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public GameObject gameObjectToPlaceSize;
    Transform cube, sphere, cylinder, peasant;

    public LayerMask groundLayerMask;
    public int gridSize;


    private bool placeObjectActive, canPlace, blockChosen;
    private  MeshRenderer mesh;
    private Transform toPlace;
    private Vector3 cursorPos;
    private List<Transform> peasantCount = new List<Transform>();

    void Start(){
        //Loading in prefabs
        cube = Resources.Load<Transform>("Buildings/Cube");
        sphere = Resources.Load<Transform>("Buildings/Sphere");
        cylinder = Resources.Load<Transform>("Buildings/Cylinder");
        peasant = Resources.Load<Transform>("Peasant");

        //Events
        EventHandler.OnCollisionWithScenery += GetCollision;
        EventHandler.OnCollisionWithSceneryExit += ExitCollision;

        //Assigning
        mesh = gameObjectToPlaceSize.GetComponent<MeshRenderer>();

        //Other stuff
        gameObjectToPlaceSize.SetActive(placeObjectActive);
        blockChosen = false;
        canPlace = true;

    }

    void Update(){

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity)){
            if(Input.GetMouseButtonDown(0)){
                if(hitInfo.collider.tag == "Home"){
                    Home.Instance.GetInventory();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            toPlace = cube;
            ToggleBlockChosen();
            TogglePlaceObjectSize();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            toPlace = sphere;
            ToggleBlockChosen();
            TogglePlaceObjectSize();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)){
            toPlace = cylinder;
            ToggleBlockChosen();
            TogglePlaceObjectSize();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4)){
            toPlace = peasant;
            ToggleBlockChosen();
            TogglePlaceObjectSize();
        }
        if(Input.GetMouseButtonDown(0) && blockChosen){
            PlaceUnit(toPlace);
        }
    }


    void LateUpdate(){
        ShowObject(gameObjectToPlaceSize);
    }

    void PlaceUnit(Transform objectToPlace){
        Vector3 worldPos;
        if(objectToPlace != null){
            worldPos = new Vector3(gameObjectToPlaceSize.transform.position.x, 0.5f, gameObjectToPlaceSize.transform.position.z);           
        }
        else{
            worldPos = new Vector3(0,0,0);
        }
        if(canPlace){
            if(objectToPlace == peasant){
                peasantCount.Add(peasant);
                objectToPlace.name = "Peasant " + peasantCount.Count;
            }
            Instantiate(objectToPlace, worldPos, default);
            blockChosen = false;
        }
        else{
            Debug.Log("Can't place here!");
        }
        
    }
    public void ShowObject(GameObject placeObject){
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, groundLayerMask)){ 
            if(placeObjectActive && Input.GetMouseButtonDown(0) && canPlace){

                TogglePlaceObjectSize();
            }
            if(placeObjectActive){
                cursorPos.x = Mathf.Floor(hitInfo.point.x / gridSize) * gridSize;
                cursorPos.z = Mathf.Floor(hitInfo.point.z / gridSize) * gridSize;
                cursorPos.y = 0.5f;
            }
            else{
            cursorPos = hitInfo.point;
            }
            placeObject.transform.position = cursorPos;
        }
    }
    void GetCollision(Collider col){
        if(col.gameObject.layer == 8 || col.gameObject.layer == 10){
            mesh.material.SetColor("_Color", Color.red);
            canPlace = false;
        }
    }

    void ExitCollision(Collider col){
        mesh.material.SetColor("_Color", Color.blue);
        canPlace = true;
    }


    internal void TogglePlaceObjectSize(){
        placeObjectActive = !placeObjectActive;
        gameObjectToPlaceSize.SetActive(placeObjectActive);
    }

    internal void ToggleBlockChosen(){
        blockChosen = !blockChosen;
    }

}
