/*---------------------------------------------------
 * 制作日 : 2018年10月18日
 * 制作者：シスワントレサ
 * 内容　：A－ボタンのアニメーションを管理
 * 最後の更新：2018年10月18日
 * ----------------------------------------------- */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Animator))]
public class ButtonAPressed : MonoBehaviour {

    // ボタンのアニメーション管理
    private Animator anim;

    // 初期化
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // 開いている中
    public void CurrentlyOpened(bool isOpen)
    {
        if (isOpen) // 開いているか？
            anim.SetBool("isClicked", true);
        else
            anim.SetBool("isClicked", false);
    }
} // !_class
