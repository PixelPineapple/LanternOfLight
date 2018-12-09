/*---------------------------------------------------
 * 制作日 : 2018年09月29日
 * 制作者：シスワントレサ
 * 内容　：エベントを聞きたいクラスはGameEventListenerを追加
 * 最後の更新：2018年09月29日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {

    // 呼び出したいメソッドはここに登録する
    public GameEvent gameEvent;
    // 呼び出されるエベント「メソッド」
    public UnityEvent events;
    
    private void OnEnable()
    {
        // ゲームエベントに登録
        gameEvent.RegisterEvent(this);
    }

    private void OnDisable()
    {
        // 登録を解除する
        gameEvent.UnregisterEvent(this);
    }

    /// <summary>
    /// 応答を呼び出す。
    /// </summary>
    public void OnEventRaised()
    {
        // メソッドを実行する
        events.Invoke();
    }

} // !class
