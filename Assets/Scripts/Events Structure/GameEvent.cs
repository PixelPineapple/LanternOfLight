/*---------------------------------------------------
 * 制作日 : 2018年09月29日
 * 制作者：シスワントレサ
 * 内容　：Eventを管理する、スクリプタブルオブジェクト
 * 最後の更新：2018年09月29日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject {

    // このエベントを聞きたいリスナー
    private List<GameEventListener> listeners
        = new List<GameEventListener>();
    
    /// <summary>
    /// エベントが始まる。
    /// </summary>
    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    /// <summary>
    ///  エベントに追加。
    /// </summary>
    /// <param name="listener"></param>
    public void RegisterEvent(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    /// <summary>
    /// エベントから削除。
    /// </summary>
    /// <param name="listener"></param>
    public void UnregisterEvent(GameEventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}   // !_class
