using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestManager : MonoBehaviour {

    public EventSystem eventSystem;

    // カメラ関係
    public Camera mainCamera;

    // ray関係
    public Ray ray;
    public RaycastHit hit;
    public GameObject selectedGameObject;

    // ゲームスクリプト
    //public ItemList itemList;


    // アイテムボタンオブジェクトのリスト
    public List<GameObject> btnList = new List<GameObject>();

    public Sprite RedSprite;
    public Sprite BlueSprite;
    public Sprite GreenSprite;

    //Door
    public GameObject greenDoor;
    
    // Use this for initialization
    void Start () {

        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //itemList = ItemList.getInstance();

        int i = 0;
        while(GameObject.Find("Button (" + i.ToString() + ")") != null){
            btnList.Add(GameObject.Find("Button (" + i.ToString() + ")"));
            i++;
        }

    }
    
    // Update is called once per frame
    void Update () {
        if(Input.GetMouseButtonUp(0)){
            selectedGameObject = eventSystem.currentSelectedGameObject;
            if(selectedGameObject == null){
                searchRoom();
            } else if(selectedGameObject.tag == "ItemListButton"){
                //itemList.click(selectedGameObject);
            } else if(selectedGameObject.name == "RemoveButton"){
                //itemList.removeSelectedItem();
            }
        }
    }

    public void searchRoom(){
        selectedGameObject = null;
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 10000000, 1 << 8)){
            
            selectedGameObject = hit.collider.gameObject;
            //itemList.add(selectedGameObject.name);

            add(selectedGameObject.name);

            Destroy(selectedGameObject);

            switch(hit.collider.gameObject.name){
                case "RedBall":
                    Debug.Log("RedBall");
                    break;
                case "BlueBall":
                    Debug.Log("BlueBall");
                    break;
                case "GreenBall":
                    Debug.Log("GreenBall");
                    Destroy(greenDoor);
                    break;
                default:
                    Debug.Log("default");
                    break;
            }

        }
    }

    // アイテムをリストに追加する
    public void add(string item_name){

        for(int i=0; i<btnList.Count; i++){
            string im_name = btnList[i].GetComponent<Image>().sprite.name;

            Debug.Log("im_name:" + im_name);
            
            if(im_name == "no_Image"){
                //btnList[i].GetComponent<Image>().sprite = Resources.Load("Images/" + item_name, typeof(Sprite)) as Sprite;

                switch(item_name){
                case "RedBall":
                    btnList[i].GetComponent<Image>().sprite = RedSprite;
                    break;
                case "BlueBall":
                    btnList[i].GetComponent<Image>().sprite = BlueSprite;
                    break;
                case "GreenBall":
                    btnList[i].GetComponent<Image>().sprite = GreenSprite;
                    break;
                default:
                    Debug.Log("default");
                    break;
                }

                break;
            }

        }

    }

}

