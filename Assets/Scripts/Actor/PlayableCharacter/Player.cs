/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：プレイヤの状態を管理するクラス
 * 最後の更新：2018年11月10日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (CharacterController2D))]
public class Player : MonoBehaviour {

    #region Player Condition
    // プレイヤの状況
    public enum PlayerCondition
    {
        CONTROLLABLE = 0,       // 入力が獲得できる
        ISTALKING = 1,              // 人間と話す
        LOOKINVENTORY = 2     // インベントリーを見る
    }
    // プレイヤの状況
    private PlayerCondition pCondition;
    public PlayerCondition PCondition
    {
        get { return pCondition; }
        set { pCondition = value; }
    }
    #endregion

    #region Player Movement
    // プレイヤの移動速度
    float moveSpeed = 2f;
    
    // キャラクタコントローラー
    CharacterController2D controller;
    public CharacterController2D Controller
    {
        get { return controller; }
    }

    // 速度
    Vector3 velocity;
    // 入力
    Vector2 directionalInput;
    // 速度平滑化
    float velocitySmoothing;
    #endregion
    // アニメーション
    Animator anim;
    // 青い灯籠「人生の本質」を持ってるのか？
    public PickablesData blueLantern;

    // 初期化
    private void Awake()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
        PCondition = PlayerCondition.CONTROLLABLE;
    }
    
    private void OnEnable()
    {
        // 「人生の本質」を持てば、エベントを呼ぶ「アニメーションを切り替える」
        if (blueLantern.isPicked)
        {
            PreloadComponent.events.pickingLanternEvent.Raise();
        }
    }

    // 更新
    void Update ()
    {
        // 速度を計算する
        CalculateVelocity();
        // キャラクタを移動させる
        controller.Move(velocity * Time.deltaTime, directionalInput);
    }

    // 方向の入力
    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    // 速度の計算メソッド
    void CalculateVelocity()
    {
        // 走るギミック
        if (Input.GetKeyDown(KeyCode.C))
        {
            moveSpeed = 3.5f;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            moveSpeed = 2f;
        }
        // プレイヤを動かせる
        velocity.x = directionalInput.x * moveSpeed;
        velocity.y = directionalInput.y * moveSpeed;
    }


    // どんなアニメションを使う？
    void UseLanternAnimation()
    {
        anim.SetLayerWeight(1, 1);
    }

    // プレイヤの現在状況を設定
    public void PlayCondition(int value)
    {
        pCondition = (PlayerCondition) value;
    }

}   // !_class
