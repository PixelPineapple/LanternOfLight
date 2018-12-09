/*---------------------------------------------------
 * 制作日 : 2018年10月04日
 * 制作者：シスワントレサ
 * 内容　：次の対話を出すためのボタン
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceToNextDialogue : MonoBehaviour {

    // 対話マネージャー
    [SerializeField]
    private DialogueManager dm;

    // 更新
    private void Update()
    {
        // 対話を進む
        if (gameObject.activeInHierarchy && 
            Input.GetKeyDown(KeyCode.X) && dm.IsTalking)
        {
            // Moving to the next script;
            dm.ContinueConversation();
        }
    }
}   // !_class
