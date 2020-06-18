using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //　スタートボタンを押したら実行する
	public void StartGame() {
		SceneManager.LoadScene ("escapeSimulater");
	}
    //　スタートボタンを押したら実行する
    public void loopStartGame() {
        SceneManager.LoadScene ("endlessLoop");
    }

}
