/*---------------------------------------------------
 * 制作日 : 2018年09月27日
 * 制作者：シスワントレサ
 * 内容　：プレイヤが得られたアイテムの情報
 * 最後の更新：2018年09月30日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PickablesData : ScriptableObject {

    #region description
    public new string name;     // アイテム名
    public string kanjiName;     // 漢字名
    [TextArea (3, 10)]
    public string description;     // アイテム説明
    public Sprite artwork;         // アーツ 
    public Sprite pixelArts;        // ドット絵の画像
    #endregion

    #region isPickedUp
    public bool isPicked;           // 獲得しましたか？
    #endregion
} // !_class
