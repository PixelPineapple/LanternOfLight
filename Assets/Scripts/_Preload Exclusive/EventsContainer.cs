/*---------------------------------------------------
 * 制作日 : 2018年10月05日
 * 制作者：シスワントレサ
 * 内容　：すべてのエベントを含むシングルトンクラス
 * 最後の更新：2018年10月05日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsContainer : MonoBehaviour {

    // プレイヤがたまに使うゲームエベント
    #region Mostly Used by Player
    // ランタンを取るエベント
    public GameEvent pickingLanternEvent;
    // コレクタブルアイテムを獲得するエベント
    public GameEvent foundPickableEvent;
    // 人間AIと対話するエベント
    public GameEvent humanInteraction;
    // 人間AIは話している中のエベント
    public GameEvent playerIsTalking;
    // 主人公はインベントリーを開く
    public GameEvent playerisOpeningInventory;
    // プレイヤは入力が受け取られるかのエベント
    public GameEvent playerIsControllable;
    #endregion

    // 敵AIがたまに使うゲームエベント
    #region Mostly Used by Enemy
    // 敵がプレイヤに当たるのエベント
    public GameEvent hitEvent;
    #endregion

    // GUIのエベント
    #region Mostly Used To Update GUI
    // インベントリーを更新するエベント
    public GameEvent updateInventory;
    #endregion
}   // !_class
