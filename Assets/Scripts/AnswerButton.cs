using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    
    //InputFieldを格納するための変数
    public InputField inputField;

    public GameObject door1;
    public GameObject question1;

    public static GameObject questionCanvas;

    int nazo_num = 0;

    void Start () {
        questionCanvas = GameObject.Find("QuestionCanvas");
    }
    
    public void OnClick()
    {
        //Debug.Log("");  // ログを出力
        //InputFieldからテキスト情報を取得する
        string name = inputField.text;

        Debug.Log("Answer:" + name);

        nazo_num = PlayerPrefs.GetInt("nazo", 0);

        switch(nazo_num){
            case 1:
                if (name == "なぞ") {
                    Destroy(door1);
                    Destroy(question1);
                    questionCanvas.SetActive(false);
                }
                break;
            case 2:
                
                break;
            case 3:
                
                break;
            case 4:
                
                break;
            case 5:
                
                break;
                
            }
        
        Debug.Log("nazoName:" + nazo_num);

    }

}
