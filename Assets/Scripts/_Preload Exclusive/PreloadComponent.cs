/*---------------------------------------------------
 * 制作日 : 2018年10月05日
 * 制作者：シスワントレサ
 * 内容　：どこからでも呼べるスタティッククラスはここにまとめなさい
 * 最後の更新：2018年10月05日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class PreloadComponent {

    // エベントコンテナクラス
    public static EventsContainer events;
    // ゲームオーバークラス
    public static GameOver gameOver;
    // 獲得されたアイテムをリセット
    public static ResetPickablesData resetPD;
    // サウンドマネージャークラス
    public static SoundManager soundManager;
    
    // プリロードコンポネント
    static PreloadComponent()
    {
        // ゲームオブジェクトをプリロードシーンの中に探す
        GameObject g = SafeFind("_App");
        // ゲームオブジェクトのコンポネントの初期化
        events = (EventsContainer)SafeComponent(g, "EventsContainer");
        gameOver = (GameOver)SafeComponent(g, "GameOver");
        resetPD = (ResetPickablesData)SafeComponent(g, "ResetPickablesData");

        //  サウンドマネージャーを初期化する
        GameObject sound = SafeFind("SoundManager");
        // サウンドマネージャのコンポネントの初期化
        soundManager = (SoundManager)SafeComponent(sound, "SoundManager");
    }

    // ゲームオブジェクトを探す
    private static GameObject SafeFind(string s)
    {
        GameObject g = GameObject.Find(s);
        if (g == null) Woe("Component " + s + " not on _Preload.");
        return g;
    }

    // コンポネントを探す
    private static Component SafeComponent (GameObject g, string s)
    {
        Component c = g.GetComponent(s);
        if (c == null) Woe("Component " + s + " not on _Preload.");
        return c;
    }

    // ゲームオブジェクトまたはコンポネントが見つかれないときのエラー管理のメソッド
    private static void Woe(string error)
    {
        Debug.Log(">>> Cannot proceed... " + error);
        Debug.Log(">>> It is very likely you just forgot to launch");
        Debug.Log(">>> from scene zero, the _Preload scene.");
    }
}   // !_class
