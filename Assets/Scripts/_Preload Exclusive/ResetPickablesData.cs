/*---------------------------------------------------
 * 制作日 : 2018年10月9日
 * 制作者：シスワントレサ
 * 内容　：獲得したアイテムをリセット
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPickablesData : MonoBehaviour {

    [SerializeField]
    Inventory inventory;    // 主人公のインベントリー

    // ゲームアップリを終了する時
    private void OnApplicationQuit()
    {
        // 獲得アイテムをリセット
        ResetAllPickablesData();
    }

    // 獲得アイテムをリセットするメソッド
    public void ResetAllPickablesData()
    {
        foreach (var x in inventory.playerInventory)
        {
            x.isPicked = false;
        }
    }
}   // !_class
