using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DoorScript : MonoBehaviour
{
    //　ドアエリアに入っているかどうか
    private bool isNear;

    //　ドアのアニメーター
    private Animator animator;

 	public GameObject cameraBoard;

    public EventSystem eventSystem;

    // カメラ関係
    public Camera mainCamera;
    // ray関係
    public Ray ray;
    public RaycastHit hit;
    public GameObject selectedGameObject;

    void Start() {

        isNear = false;
        animator = transform.parent.GetComponent<Animator>();

        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

    }   
    
    void Update() {
        if(Input.GetMouseButtonUp(0) && isNear){
            
            if (eventSystem.currentSelectedGameObject == null) {
                 searchRoom();
            }

        }
    }

    public void searchRoom(){
        selectedGameObject = null;
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 10000000, 1 << 11)){
            selectedGameObject = hit.collider.gameObject;

            animator.SetBool("Open", !animator.GetBool("Open"));
            //selectedGameObject.transform.Rotate (180, -90, 0);
            
        }
    }
    
    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            isNear = true;
        }
    }
 
    void OnTriggerExit(Collider col) {
        if (col.tag == "Player") {
            isNear = false;
        }
    }


}
