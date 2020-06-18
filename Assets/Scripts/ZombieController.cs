using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;

public class ZombieController : MonoBehaviour
{

	//オブジェクトの速度
    public float speed = 0.01f;
    //オブジェクトの横移動の最大距離
    public float basePostion = 0.0f;
    public float max_z = 3.0f;

    //ユニティちゃんを格納する変数
    public GameObject player;
    //テキストを格納する変数
    public GameObject text;
 
    //ゲームオーバー判定
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //フレーム毎speedの値分だけx軸方向に移動する
        this.gameObject.transform.Translate(0, 0, speed);

        Debug.Log("z:" + (this.gameObject.transform.position.z - basePostion));

        //Transformのxの値が一定値を超えたときに向きを反対にする
        if (this.gameObject.transform.position.z - basePostion > max_z || this.gameObject.transform.position.z - basePostion < (-max_z))
        {
            speed *= -1;
            //this.transform.Rotate(new Vector3(0,0,180));
            Debug.Log("Reverse");
        }

    }

    //ユニティちゃんとの当たり判定
    private void OnCollisionEnter(Collision other)
    {
        //接触したオブジェクトがユニティちゃんのとき
        if(other.gameObject.name == player.name)
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
        }
    }

    //シーンを再読み込みする
    private void Restart()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene("Title");
    }

}
