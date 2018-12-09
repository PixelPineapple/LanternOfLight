/*---------------------------------------------------
 * 制作日 : 2018年11月09日
 * 制作者：シスワントレサ
 * 内容　：インベントリナビ
 * 最後の更新：2018年11月09日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NavigateInventory : MonoBehaviour {
    
    // デフォルトに選択されたオブジェクト
    [SerializeField]
    private Selectable defaultSelectables;

    // エベントシステム
    public EventSystem _eventSystem;

    void OnEnable ()
    {
        Debug.Log("On Enable default selection selected");
        //defaultSelectables.Select();	
        StartCoroutine(WaitTobeSelected());
	}

    // Coroutineを使う目的は「Unity will not highlight the only 1 object in the inventory unless we do a mouse click beforehand even with .Select() method」
    IEnumerator WaitTobeSelected()
    {
        yield return null;
        _eventSystem.SetSelectedGameObject(null);
        _eventSystem.SetSelectedGameObject(defaultSelectables.gameObject);
    }
} // !_class
