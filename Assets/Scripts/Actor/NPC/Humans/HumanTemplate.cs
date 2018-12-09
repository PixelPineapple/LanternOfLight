/*---------------------------------------------------
 * 制作日 : 2018年09月29日
 * 制作者：シスワントレサ
 * 内容　：人間のデータを持つ「スクリプタブルオブジェクト」
 * 最後の更新：2018年10月4日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HumanTemplate : ScriptableObject
{
    // 人間の名前
    public new string name;
    // 人間の肖像
    public Sprite portrait;

    #region　プレイヤが探している人間？
    public bool isCorrect;
    #endregion

    #region 人間が持つ対話
    [TextArea(3, 10)]
    public string[] sentences;
    #endregion
}   // !_class
