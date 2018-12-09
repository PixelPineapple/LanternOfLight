/*---------------------------------------------------
 * 制作日 : 2018年10月01日
 * 制作者：シスワントレサ
 * 内容　：スプライトのポジションを並び替える
 *              無生物が使ったスプライトソート
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] // エディターでゲームオブジェクトを並び替えるように
public class StaticSpriteSorting : MonoBehaviour {
    void Update()
    {
        gameObject.GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -10);
    }
} // !_class
