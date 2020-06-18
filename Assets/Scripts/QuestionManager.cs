using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestionManager : MonoBehaviour
{

	public EventSystem eventSystem;
    
    // カメラ関係
    public Camera mainCamera;

    // ray関係
    public Ray ray;
    public RaycastHit hit;
    public GameObject selectedGameObject;

    public Image questionImage;
    public static GameObject questionCanvas;

    public string nazoName = "";

    public Sprite nazo1Sprite;
    public Sprite nazo2Sprite;
    public Sprite nazo3Sprite;
    public Sprite nazo4Sprite;
    public Sprite nazo5Sprite;

    // Use this for initialization
    void Start () {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        questionCanvas = GameObject.Find("QuestionCanvas");
        questionImage = GameObject.Find("questImage").GetComponent<Image>();
        questionCanvas.SetActive(false);
        // テキストメッセージの初期化
         //QuestionMessage.init("QuestionCanvas", "messageBox");
    }
    
    // Update is called once per frame
    void Update () {
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
        if(Physics.Raycast(ray, out hit, 10000000, 1 << 9)){
            selectedGameObject = hit.collider.gameObject;
            
            //QuestionMessage.Load(selectedGameObject.name);

            questionCanvas.SetActive(true);

            if (questionCanvas.activeSelf == false) {
                questionCanvas.SetActive(true);
            }

            //questionImage.GetComponent<Image>().sprite = nazo1Sprite;
            
            nazoName = selectedGameObject.name;

            switch(selectedGameObject.name){
            case "nazo1":
                questionImage.sprite = nazo1Sprite;
                PlayerPrefs.SetInt("nazo",1);
                break;
            case "nazo2":
                questionImage.sprite = nazo2Sprite;
                PlayerPrefs.SetInt("nazo",2);
                break;
            case "nazo3":
                questionImage.sprite = nazo3Sprite;
                PlayerPrefs.SetInt("nazo",3);
                break;
            case "nazo4":
                questionImage.sprite = nazo4Sprite;
                PlayerPrefs.SetInt("nazo",4);
                break;
            case "nazo5":
                questionImage.sprite = nazo5Sprite;
                PlayerPrefs.SetInt("nazo",5);
                break;
                
            }

            // switch(selectedGameObject.name){
            //     case "Box":
            //         TextMessage.Load("Text/Box");
            //         break;
            //     case "Ball":
            //         TextMessage.Load("Text/Ball");
            //         break;
            //     case "Cylinder":
            //         TextMessage.Load("Text/Cylinder");
            //         break;
            // }
            
        }
    }

}
