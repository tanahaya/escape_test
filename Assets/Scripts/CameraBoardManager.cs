using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraBoardManager : MonoBehaviour
{

	public GameObject cameraBoard;

    public EventSystem eventSystem;
    // カメラ関係
    public Camera mainCamera;
    // ray関係
    public Ray ray;
    public RaycastHit hit;
    public GameObject selectedGameObject;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        cameraBoard = GameObject.Find("CameraBoard");
        cameraBoard.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonUp(0)){

            //保険として残します。
            // if(questionCanvas.activeSelf) {
            //     questionCanvas.SetActive(false);
            // } else if (eventSystem.currentSelectedGameObject == null) {
            //     searchRoom();
            // }
            
            if (eventSystem.currentSelectedGameObject == null) {
                 searchRoom();
            }

        }

    }

    public void searchRoom(){
        selectedGameObject = null;
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 10000000, 1 << 10)){
            selectedGameObject = hit.collider.gameObject;
            
            //QuestionMessage.Load(selectedGameObject.name);

            cameraBoard.SetActive(true);
            
            
        }
    }
}
