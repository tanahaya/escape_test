using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddRoom : MonoBehaviour
{

	public List<List<int>> roomList = new List<List<int>>();

    // Start is called before the first frame update
    void Start()
    {
    	
    	List<int> intList = new List<int>();
    	intList.Add(0);
    	intList.Add(0);

		roomList.Add(intList);

		//Debug.Log("x: " + myList[0][0]);
		//Debug.Log("y: " + myList[0][1]);

        //GameObject obj = (GameObject)Resources.Load ("Room");
        //GameObject room1 = Instantiate (obj, new Vector3(27.0f,0.0f,9.0f), Quaternion.identity);
        //room.name = "Room2";
        //room.transform.Find("Canvas/Text").gameObject.GetComponent<Text>().text = "abc";

        // GameObject room2 = Instantiate (obj, new Vector3(45.0f,0.0f,9.0f), Quaternion.identity);
        // GameObject room3 = Instantiate (obj, new Vector3(9.0f,0.0f,-9.0f), Quaternion.identity);
        // GameObject room4 = Instantiate (obj, new Vector3(-9.0f,0.0f,9.0f), Quaternion.identity);
        // GameObject room5 = Instantiate (obj, new Vector3(9.0f,0.0f,27.0f), Quaternion.identity);


    }

    // Update is called once per frame
    void Update()
    {

    }

}
