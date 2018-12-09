/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：全体のゲームを管理するクラス
 * 
 *  !!!! もう使わない !!!! Singletonクラスは使わないように、Preload Sceneを使う。
 * ----------------------------------------------- */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    #region Singleton / シングルトンクラス
    [HideInInspector]
    public static GameManager _instance;
    [SerializeField]
    private GameObject playerPrefab;

    private void MakeSingleton()
    {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            DontDestroyOnLoad(gameObject);
            }
    }
    #endregion

    [HideInInspector]
    public PlayerPrefs playerPref;

    // 初期化
    void Awake() {
        // シングルトンを生成
        MakeSingleton();
        playerPref.Reset();
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneChanged;
    }

    // プレイヤはランタン「人生の本質」を持っているのかのストラック
    public struct PlayerPrefs
    {
        public bool isHoldingLantern;

        public void Reset()
        {
            isHoldingLantern = false;
        }
    }

    // シーンを切り替えるとき、プレイヤを生成
    public void OnSceneChanged (Scene name, LoadSceneMode mode)
    {
        Instantiate(playerPrefab);
    }
} // !_class 


