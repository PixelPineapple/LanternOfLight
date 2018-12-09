/*---------------------------------------------------
 * 制作日 : 2018年10月28日
 * 制作者：シスワントレサ
 * 内容　：近すぎるプレイヤーを検出するために使用される検出器
 * 最後の更新：2018年11月09日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController2D))]
public class CircleDetector : MonoBehaviour {

    // 半径
    [SerializeField]
    private float radius;
    public float Radius
    {
        get { return radius; }
    }

    // プレイヤのレイヤーをここに参考
    public LayerMask layerMask;

    // ターゲット
    [SerializeField]
    private GameObject target;
    // 追いかけるエベント
    [SerializeField]
    private GameEvent hitEvent;

    // キャラクタコントローラー
    CharacterController2D cc2D;

    // 初期化
    private void Start()
    {
        cc2D = GetComponent<CharacterController2D>();
    }

    // 更新
    private void Update()
    {
        Radar();
    }

    // 円形のRaycastを生成して、プレイヤと当たる場合はエベントを呼ぶ
    public void Radar()
    {
        float directionX = cc2D.collisionInfos.faceDir;
        
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.right * directionX, 0, layerMask);

        if(hit)
        {
            // 「プレイヤが見つかる」エベントを呼ぶ。
            hitEvent.Raise();
            hitEvent.UnregisterEvent(gameObject.GetComponent<GameEventListener>());
        }
        
    }
} //!_class
