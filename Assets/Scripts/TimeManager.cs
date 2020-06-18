using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityChan;
using UnityEngine.SceneManagement;
 
public class TimeManager : MonoBehaviour
{
    //時間表示用テキスト
    public Text timeText;
    //制限時間
    public float limit = 60.0f;
    //ゲームオーバー表示用テキスト
    public GameObject text;
    //ユニティちゃん格納用
    public GameObject player;
 
    //ゲームオーバー判定
    private bool isGameOver = false;
 
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "残り時間:" + limit + "分";
    }
 
    // Update is called once per frame
    void Update()
    {
        //ゲームオーバー状態で画面がクリックされたとき
        if (isGameOver && Input.GetMouseButton(0))
        {
            Restart();
        }
 
        //時間制限がきたとき
        if(limit < 0)
        {
            //ゲームオーバーを表示する
            text.GetComponent<Text>().text = "GameOver...";
            text.SetActive(true);
 
            //ユニティちゃんを動けなくする
            player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
            //アニメーションをオフにする
            player.GetComponent<Animator>().enabled = false;
 
            //ゲームオーバー
            isGameOver = true;
 
            //ここでUpdateメソッドを終わらせる
            return;
        }
 
        //時間をカウントダウンする
        limit -= Time.deltaTime;
        timeText.text = "残り時間:" + limit.ToString("f1") + "分";
    }
 
    //シーンを再読み込みする
    private void Restart()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
    }
}