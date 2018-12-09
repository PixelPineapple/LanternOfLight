/*---------------------------------------------------
 * 制作日 : 2018年09月29日
 * 制作者：シスワントレサ
 * 内容　：プレイヤは他のゲームオブジェクトと対応を管理するクラス
 * 最後の更新：2018年09月29日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Player))]
public class PlayerEventListener : MonoBehaviour {

    // プレイヤのクラスを参考にする
    Player player;

	// 初期化
	void Start () {
        player = GetComponent<Player>();
        player.Controller.interactableEvents += FoundInteraction;
	}

    // プレイヤは世界とインタラクション
    void FoundInteraction(GameObject other)
    {
        // プレイヤの現在状況は「入力が獲得できる」
        if (player.PCondition == Player.PlayerCondition.CONTROLLABLE)
        {
            // インタラクションボタンを押す。
            if (Input.GetKeyDown(KeyCode.X))
            {
                switch (other.transform.tag)
                {
                    case "Lantern": // 「人生の本質」とインタラクション
                        PreloadComponent.events.pickingLanternEvent.Raise();
                        break;
                    case "Pickable": // コレクタブルアイテムとインタラクション
                        other.GetComponent<GameEventListener>().enabled = true;
                        //エベントを呼ぶ
                        PreloadComponent.events.foundPickableEvent.Raise();
                        break;
                    case "Human": // 人間とインタラクション
                        other.GetComponent<GameEventListener>().enabled = true;
                        // エベントを呼ぶ
                        PreloadComponent.events.humanInteraction.Raise();
                        // プレイヤ入力を止める
                        PreloadComponent.events.playerIsTalking.Raise();
                        break;
                    case "Door": // ドアとインタラクション
                        if (player.blueLantern.isPicked)
                        {
                            // レベルをロード
                            other.GetComponent<SceneTransition>().LoadLevel();
                        }
                        else
                        {
                            // Todo: Animation or remarks to indicate that the lantern is not yet picked
                            Debug.Log("Lantern is not yet picked");
                        }
                        break;
                }
            }
        } // !_if(player.isControllable)
    }
} // !_class
