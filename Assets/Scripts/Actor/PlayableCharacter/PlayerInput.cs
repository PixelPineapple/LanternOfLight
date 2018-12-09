/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：プレイヤがが登録られたインプット
 * 最後の更新：2018年11月09日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

    // プレイヤクラスの参考
    Player player;
    // アニメーション
    Animator anim;

    #region 歩きのEFX 
    public AudioClip walk_SE;
    private bool walkingSEPlaying;
    #endregion

    // 初期化
    void Start () {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }
	
	// 更新
	void Update () {
        Vector2 directionalInput = Vector2.zero;
        // プレイヤの移動操作
        if (player.PCondition == Player.PlayerCondition.CONTROLLABLE) // 現在プレイヤは動かせるか？
        {
            // プレイヤを動かせる
            directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        // 動くアニメーションや音を管理
        IsWalking(directionalInput.magnitude, directionalInput.x);
        player.SetDirectionalInput(directionalInput);        
	}

    /// <summary>
    /// プレイヤが歩くのか？
    /// </summary>
    /// <param name="speed">速度</param>
    void IsWalking(float speed, float face)
    {
        if (speed == 0) {
            anim.SetBool("isWalking", false);
            // サウンドエフェクトを終了
            walkingSEPlaying = false;
            PreloadComponent.soundManager.efxSource.loop = false;
            return;
        }

        // 歩くのサウンドエフェクトを設定
        WalkingSound(speed);

        anim.SetBool("isWalking", true);
    }

    // 歩きEFX
    void WalkingSound(float speed)
    {
        if (speed != 0 && !walkingSEPlaying)
        {
            PreloadComponent.soundManager.efxSource.loop = true;
            PreloadComponent.soundManager.RandomizeSFX(walk_SE);
            walkingSEPlaying = true;
        }
    }
} // class
