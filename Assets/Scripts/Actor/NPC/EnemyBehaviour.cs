/*---------------------------------------------------
 * 制作日 : 2018年09月29日
 * 制作者：シスワントレサ
 * 内容　：敵の現在の行動
 * 最後の更新：2018年10月02日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Todo : Improvement
// Todo : Dashing behavior not yet implemented
public class EnemyBehaviour : MonoBehaviour {

    // エネミーの現在の行動のイナム
	public enum EnemyCurrentBehaviour
    {
        Idle,               // アイドル：そのまま立ってる
        Chasing,         // 追う：プレイヤを追いかける
        Patroling,       // パトロール：ランダムに自動で歩いている
        Charging,       // チャージ：攻撃「ダッシュ」前にチャージする
        Dashing         // ダッシュ：ダッシュ攻撃
    }

    // エネミーの現在の行動
    [SerializeField]
    EnemyCurrentBehaviour ecb;
    public EnemyCurrentBehaviour Ecb
    {
        get
        {
            return ecb;
        }

        set
        {
            ecb = value;
        }
    }
    // キャラクタコントローラークラス
    private CharacterController2D cc2d;

    // ターゲットプレイヤ
    [SerializeField]
    private GameObject player;
    // プレイヤから離れた距離
    public float distanceToPlayer;

    // 敵のアニメーション
    Animator anim;

    #region Charging For Attack
    // 攻撃する前に必要なチャージ時間
    public float chargeTime;
    private float chargingTime;
    // 攻撃準備完了のパラメータ
    public float lockingDashTarget;
    // ダッシュのスピード
    [SerializeField]
    private float dashSpeed;
    // ダッシュターゲット
    private Vector3 dashTarget = Vector3.zero;
    #endregion

    // 初期化
    private void Start()
    {
        cc2d = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
        Ecb = EnemyCurrentBehaviour.Idle;
        chargingTime = chargeTime;
    }

    private void Update()
    {
        // 現在の行動の管理
        CurrentBehaviour();
    }

    /// <summary>
    /// EnemyCurrentBehaviour次第、敵を動かせる
    /// </summary>
    private void CurrentBehaviour()
    {
        switch(ecb)
        {
            case EnemyCurrentBehaviour.Chasing:     // 追う
                // プレイヤからの距離を獲得する
                Vector2 distance = player.transform.position - transform.position;
                // プレイヤの所に走る
                cc2d.Move(distance * Time.deltaTime);
                // 十分近いの場合
                if (distance.magnitude <= distanceToPlayer)
                {
                    // チャージし始める。
                    ecb = EnemyCurrentBehaviour.Charging;
                }
                // アニメーションを設定
                anim.SetBool("Chase", true);
                break;
            case EnemyCurrentBehaviour.Idle:        // アイドル
                // Todo : Idle behavior
                break;
            case EnemyCurrentBehaviour.Patroling:   // パトロール
                // Todo : Patroling behavior
                break;
            case EnemyCurrentBehaviour.Charging:    // チャージ
                chargingTime -= Time.deltaTime;
                // ずっとプレイヤの位置を保持する
                if (chargingTime >= lockingDashTarget)
                {
                    dashTarget = player.transform.position;
                }
                if (chargingTime <= 0)
                {
                    // ダッシュ攻撃をし始める
                    ecb = EnemyCurrentBehaviour.Dashing;
                    chargingTime = chargeTime;
                }
                break;
            case EnemyCurrentBehaviour.Dashing:     // ダッシュ攻撃
                // Todo : Dash still weird
                Vector2 dashT = Vector2.MoveTowards(transform.position, dashTarget, 10);
                transform.position = dashT;
                //cc2d.Move(dashT * Time.deltaTime);
                ecb = EnemyCurrentBehaviour.Chasing;
                break;
        }
    } // !CurrentBehaviour

    // プレイヤを追いかける
    public void BeginChasing()
    {
        Ecb = EnemyCurrentBehaviour.Chasing;
    }
}   // !_class
