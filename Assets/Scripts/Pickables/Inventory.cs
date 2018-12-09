/*---------------------------------------------------
 * 制作日 : 2018年11月09日
 * 制作者：シスワントレサ
 * 内容　：アイテムをまとめるスクリプタブルオブジェクト
 * 最後の更新：2018年11月09日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject {

    // 獲得できるアイテムを全部ここにまとめる
    public List<PickablesData> playerInventory = new List<PickablesData>();
   
} // !_class
