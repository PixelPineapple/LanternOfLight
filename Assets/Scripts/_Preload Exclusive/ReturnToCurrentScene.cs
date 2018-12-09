/*---------------------------------------------------
 * 制作日 : 2018年10月06日
 * 制作者：シスワントレサ
 * 内容　：_Preloadシーンを呼んだ後に、元のシーンに戻る。
 * 最後の更新：2018年10月06日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToCurrentScene : MonoBehaviour {

#if UNITY_EDITOR
    private void Awake()
    {
        if (LoadPreloadScene.otherScene > 0)
        {
            Debug.Log("Return to the scene: " + LoadPreloadScene.otherScene);
            SceneManager.LoadScene(LoadPreloadScene.otherScene);
        }
    }
#endif
} // !_class
