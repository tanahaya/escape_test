using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    // ボタンが押された場合、今回呼び出される関数
    public static GameObject questionCanvas;

    void Start () {

        questionCanvas = GameObject.Find("QuestionCanvas");

    }

    public void OnClick()
    {
        //Debug.Log("");  // ログを出力
        questionCanvas.SetActive(false);
    }
    
}
