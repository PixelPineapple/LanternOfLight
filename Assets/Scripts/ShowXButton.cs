/*---------------------------------------------------
 * 制作日 : 2018年10月29日
 * 制作者：シスワントレサ
 * 内容　：プレイヤの頭の上にあるX-ボタンを表示
 * 最後の更新：2018年10月29日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CircleCollider2D))]
public class ShowXButton : MonoBehaviour {

    private CircleCollider2D circleCollider; // 獲得できるアイテムにあるコライダー

    [SerializeField]
    private GameObject xButton; //主人公にある

    // 初期化
    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = 1.19f;
        circleCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ✕-ボタンを表示
        if (collision.tag == "Player" && xButton != null)
        {
            xButton.SetActive(true);
        }
        else
        {
            Debug.Log("xButtonのゲームオブジェクトがない");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // ✕-ボタンを非表示
        if (collision.tag == "Player" && xButton != null)
        {
            xButton.SetActive(false);
        }
        else
        {
            Debug.Log("xButtonのゲームオブジェクトがない");
        }
    }
}
