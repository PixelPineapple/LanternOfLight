/*---------------------------------------------------
 * 制作日 : 2018年10月01日
 * 制作者：シスワントレサ
 * 内容　：スプライトのポジションを並び替える
 *              プレイヤやシーンの中に動けるゲームオブジェクトを使ったスプライトソート
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorting : MonoBehaviour {
	// 更新
	void Update () {
        gameObject.GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -10);
	}
} // !_class
