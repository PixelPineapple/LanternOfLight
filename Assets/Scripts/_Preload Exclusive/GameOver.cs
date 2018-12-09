/*---------------------------------------------------
 * 制作日 : 2018年10月07日
 * 制作者：シスワントレサ
 * 内容　：ゲームオーバーを管理するクラス
 * 最後の更新：2018年10月07日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    // プレイヤの行動を処理する
	public void Gameover(bool playerGuess)
    {
        // プレイヤが正しい人に「人生の本質」を渡すの場合
        if (playerGuess)
        {
            // if the player guess right
            PlayerWin();
        }
        // プレイヤが間違い人に「人生の本質」を渡すの場合
        else
        {
            // if the player guess wrong
            PlayerLose();
        }
        // ゲームスタートに戻ることができるように
        StartCoroutine(ReloadFromStart());
    }

    // プレイヤが勝つ
    void PlayerWin()
    {
        // TODO : Winning condition, events, song, and UI
        Debug.Log("PlayerWin");
    }

    // プレイヤが負ける
    void PlayerLose()
    {
        // TODO : Losing condition, events, song, and UI
        Debug.Log("PlayerLose");
    }

    // ゲームタイトルに戻る
    IEnumerator ReloadFromStart()
    {
        // 勝ち負けのエベントが終わった後に、2秒を待ってて、ゲームタイトルに戻ることができる
        yield return new WaitForSeconds(2f);
        Debug.Log("press C to restart");
        bool keyPressed = false;
        // プレイヤの入力
        while(!keyPressed)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                keyPressed = true;
            }
            yield return null;
        }
        // 取ったアイテムをリセット
        gameObject.GetComponent<ResetPickablesData>().ResetAllPickablesData();
        // ゲームタイトルに戻る
        SceneManager.LoadScene(1);
    }
}   // !_class
