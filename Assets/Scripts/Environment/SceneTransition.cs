/*---------------------------------------------------
 * 制作日 : 2018年11月03日
 * 制作者：シスワントレサ
 * 内容　：シーンを切り替えるのエフェクト
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    // シーンインデックス
    [SerializeField]
    private int sceneIndex;
    // フェイドイン、フェイドアウトのエフェクト
    [SerializeField]
    private Animator panelFadeAnimator;
    // ロードパネルUI
    [SerializeField]
    private GameObject NowLoadingPanel;

    // レベルをロード
    public void LoadLevel()
    {
        //Enter();
        StartCoroutine(LoadFakeProgress());
    }

    // Loadingアニメーションをプレイヤに見せるため
    IEnumerator LoadFakeProgress()
    {
        panelFadeAnimator.SetTrigger("End");

        yield return new WaitForSeconds(1f);

        NowLoadingPanel.SetActive(true);

        float fakeProgress = 0;

        while (fakeProgress < 2)
        {
            yield return new WaitForSeconds(0.7f);
            fakeProgress++;
        }
        
        Enter();
    }

    // シーンを切り替える
    public void Enter()
    {
        SceneManager.LoadScene("TheWorld");
    }
} // !_class
