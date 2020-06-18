using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roomLocation : MonoBehaviour
{
	public int xNum;
    public int yNum;
    public bool isDone;

    // Start is called before the first frame update
    void Start()
    {
        isDone = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {

            int x = Mathf.FloorToInt(this.transform.position.x / 18) ;
            int y = Mathf.FloorToInt(this.transform.position.z / 18) ;

            Debug.Log("x: " + x );
            Debug.Log("y: " + y );

            makeNewRoom(x + 1,y);
            makeNewRoom(x + 2,y);
            makeNewRoom(x - 1,y);
            makeNewRoom(x,y + 1);
            makeNewRoom(x,y - 1);
            makeNewRoom(x,y - 2);

            //プレイヤーが来た位置
            int playerX = Mathf.FloorToInt(col.transform.position.x / 18) ;
            int playerY = Mathf.FloorToInt(col.transform.position.z / 18) ;

        }
    }


 
    void OnTriggerExit(Collider col) {
        if (col.tag == "Player") {

        }
    }

    public void makeNewRoom(int x,int y)
    {

        bool isCreted;
        isCreted = false;

        GameObject.Find ("Plane");

        List<List<int>> roomList = GameObject.Find ("makeRoom").GetComponent<AddRoom>().roomList ; 

        for ( int i  = 0 ; i < roomList.Count ; i++ ){
            //処理内容を記述
            Debug.Log("xx" + roomList[i][0]);
            Debug.Log("yy" + roomList[i][1]);

            if ((roomList[i][0] == x) && (roomList[i][1] == y)) {
                isCreted = true;
            }
        }

        if (!isCreted) {

            List<int> intList = new List<int>();
            intList.Add(x);
            intList.Add(y);
            GameObject.Find ("makeRoom").GetComponent<AddRoom>().roomList.Add(intList);

            GameObject obj = (GameObject)Resources.Load ("Room");
            GameObject room = Instantiate (obj, new Vector3(9.0f + x * 18.0f ,0.0f,9.0f + y * 18.0f), Quaternion.identity);
            room.name = "Room" + x + "-" + y;

            int z = 0;
            z = Mathf.Abs(10 - x) + Mathf.Abs(10 - y);

            room.transform.Find("Canvas/Text").gameObject.GetComponent<Text>().text = "(" + x + "," + y + "," + z + ")" ;

        }


    }

}
