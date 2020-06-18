using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackButton : MonoBehaviour
{

    public static GameObject cameraBoard;

    void Start () {
    	
        cameraBoard = GameObject.Find("CameraBoard");

    }

    public void OnClick()
    {
        cameraBoard.SetActive(false);
    }
    
}
