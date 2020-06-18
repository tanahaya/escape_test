using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemList{

    // Singleton
    private static ItemList itemList = new ItemList();

    // アイテムボタンオブジェクトのリスト
    public List<GameObject> btnList = new List<GameObject>();

    // 選択状態にあるアイテムの番号を保存する
    public int selectedItemId = -1;
    
    // 選択されている状態を示すキーワード
    public string selectedSymbol = "Selected";

    // 割り当て無し状態の画像名
    public string emptySymbol = "no_image";

    private ItemList(){
        // 存在するボタンをリストに入れる
        int i = 0;
        while(GameObject.Find("Button (" + i.ToString() + ")") != null){
            btnList.Add(GameObject.Find("Button (" + i.ToString() + ")"));
            i++;
        }
    }

    public static ItemList getInstance(){
        return itemList;
    }


    // アイテムをリストに追加する
    public void add(string item_name){

        for(int i=0; i<btnList.Count; i++){
            string im_name = btnList[i].GetComponent<Image>().sprite.name;
            if(im_name == emptySymbol){
                btnList[i].GetComponent<Image>().sprite = Resources.Load("Images/" + item_name, typeof(Sprite)) as Sprite;
                break;
            }
        }

    }

    // リスト内の選択されているアイテムを削除する
    public void removeSelectedItem(){
        
        if(selectedItemId == -1){  // 何も選択されていないなら何もしない
            return;

        } else if (selectedItemId == btnList.Count - 1){   // 一番最後のボタンなら最後だけ変える
            btnList[selectedItemId].GetComponent<Image>().sprite = Resources.Load("Images/" + emptySymbol, typeof(Sprite)) as Sprite;
            selectedItemId = -1;

        } else {    // 途中だけ取りのぞく時
            // num番目のボタンから順番に、次のボタンの画像を割り当てる
            for(int i=selectedItemId; i<btnList.Count - 1; i++){
                btnList[i].GetComponent<Image>().sprite = btnList[i+1].GetComponent<Image>().sprite;
                selectedItemId = -1;

            }
        }
        
    }

    // アイテムリストを選択したときの処理
    public void click(GameObject btnObject){
        
        string im_name = btnObject.GetComponent<Image>().sprite.name;
        // 選択されたボタンの番号を取得
        int id = int.Parse(btnObject.name.Substring("Button (".Length, btnObject.name.Length - "Button ()".Length));

        // 既に選択状態なら選択状態を解除する
        if(id == selectedItemId){

            im_name = im_name.Substring(selectedSymbol.Length);
            btnObject.GetComponent<Image>().sprite = Resources.Load("Images/" + im_name, typeof(Sprite)) as Sprite;
            selectedItemId = -1;

        } else if(im_name != emptySymbol){   // 何かのアイテムが割り当てられていたら

            // 他に選択状態のアイテムがあるなら非選択状態に変更
            if(selectedItemId != -1){
                string temp = btnList[selectedItemId].GetComponent<Image>().sprite.name.Substring(selectedSymbol.Length);
                btnList[selectedItemId].GetComponent<Image>().sprite = Resources.Load("Images/" + temp, typeof(Sprite)) as Sprite;
                selectedItemId = -1;
            }

            // 選択状態にする
            btnObject.GetComponent<Image>().sprite = Resources.Load("Images/" + selectedSymbol + im_name ,typeof(Sprite)) as Sprite;
            selectedItemId = id;
        }

    }

}