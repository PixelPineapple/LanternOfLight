/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：キャラクタの衝突判定と移動を管理するクラス
 * 最後の更新：2018年09月29日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : RaycastController {

    public CollisionInfo collisionInfos;    // キャラクタの当たり判定が保持できるためのストラクト

    [HideInInspector]
    public Vector2 playerInput;    // プレイヤの入力

    #region Interaction Events
    public delegate void Interactable(GameObject other);
    public event Interactable interactableEvents;
    #endregion

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
        collisionInfos.faceDir = 1; // プレイヤはどこ側に向かうのか？「1＝右、‐1＝左」
	} // !Start

    /// <summary>
    /// AI用のMoveメソッド
    /// </summary>
    /// <param name="moveAmount">ゲームオブジェクトの移動量</param>
    public void Move(Vector2 moveAmount)
    {
        Move(moveAmount, Vector2.zero);
    } // !Move

    /// <summary>
    /// このスクリプトで管理するゲームオブジェクトを動かせる
    /// </summary>
    /// <param name="moveAmount">ゲームオブジェクトの移動量</param>
    /// <param name="input">プレイヤの入力</param>
	public void Move(Vector2 moveAmount, Vector2 input)
    {
        UpdateRayCastOrigins();
        collisionInfos.Reset();
        collisionInfos.moveAmountOld = moveAmount;
        playerInput = input;

        if (moveAmount.x != 0) // 水平に動く
        {
            collisionInfos.faceDir = (int)Mathf.Sign(moveAmount.x);
            transform.localScale = new Vector3(collisionInfos.faceDir, Mathf.Abs(collisionInfos.faceDir), Mathf.Abs(collisionInfos.faceDir));
        }

        HorizontalCollision(ref moveAmount); // 水平衝突のチェック

        if (moveAmount.y != 0) // 垂直衝突のチェック
        {
            VerticalCollision(ref moveAmount);
        }

        transform.Translate(moveAmount); // キャラクタを移動させる
	}

    /// <summary>
    /// 水平衝突判定
    /// </summary>
    /// <param name="moveAmount">プレイヤの移動量</param>
    void HorizontalCollision(ref Vector2 moveAmount)
    {
        float directionX = collisionInfos.faceDir;
        //float directionX = direction;
        float rayLength = Mathf.Abs(moveAmount.x) + skinWidth;

        if (Mathf.Abs(moveAmount.x) < skinWidth)
        {
            // 1 Skin width is to cast the ray to the edge of the collider, 
            // the other is to cast the ray outside small enough to detect a wall.
            rayLength = 2 * skinWidth;
        }

        for (int i = 0; i < horizontalRayCount; i++) // 水平光線のループ
        {
            // どこから光線を発射したいのか？
            Vector2 rayOrigin = (directionX == -1) ? rayCastOrigins.bottomLeft : rayCastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.right * directionX, Color.red); // Rayのデバッガー

            if (hit)
            {
                if (hit.distance == 0) continue;

                moveAmount.x = (hit.distance - skinWidth) * directionX;
                rayLength = hit.distance;

                collisionInfos.left = directionX == -1;
                collisionInfos.right = directionX == 1;

                // 拾い上げられる物を見つける
                if (hit.transform.gameObject.layer == 10)
                {
                    // エベントを呼び出す
                    if (interactableEvents != null)
                    {
                        interactableEvents(hit.transform.gameObject);
                    }
                }
            }
        }
    } // !HorizontalCollision
    
    /// <summary>
    /// 垂直衝突判定
    /// </summary>
    /// <param name="moveAmount">プレイヤの移動量</param>
    void VerticalCollision(ref Vector2 moveAmount)
    {
        float directionY = Mathf.Sign(moveAmount.y);
        //float directionY = direction;
        float rayLength = Mathf.Abs(moveAmount.y) + skinWidth;

        if (Mathf.Abs(moveAmount.y) < skinWidth)
        {
            // 1 Skin width is to cast the ray to the edge of the collider, 
            // the other is to cast the ray outside small enough to detect a wall.
            rayLength = 2 * skinWidth;
        }

        for (int i = 0; i < verticalRayCount; i++)
        {
            // Raycastをどこから発射する
            Vector2 rayOrigin = (directionY == -1) ? rayCastOrigins.bottomLeft : rayCastOrigins.topLeft;
            // いくつかのRaycastを発射する
            rayOrigin += Vector2.right * (verticalRaySpacing * i + moveAmount.x);
            // Raycastを発射する
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            // Raycastをデバッグ
            Debug.DrawRay(rayOrigin, Vector2.up * directionY, Color.red);

            // コライダーを当たる時
            if (hit)
            {
                moveAmount.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;

                collisionInfos.below = directionY == -1;
                collisionInfos.above = directionY == 1;

                // 拾い上げられる物を見つける
                if (hit.transform.gameObject.layer == 10)
                {
                    // エベントを呼び出す
                    if (interactableEvents != null)
                    {
                        interactableEvents(hit.transform.gameObject);
                    }
                }

            }
        }
    } // !VerticalCollision

    /// <summary>
    /// 衝突判定の情報
    /// </summary>
    public struct CollisionInfo
    {
        public bool above, below;    // 上、下
        public bool left, right;    // 左、右

        public int faceDir;    // 
        public Vector2 moveAmountOld;

        public void Reset()
        {
            above = below = false;
            right = left = false;
        }
    } // !_CollisionInfo

} // !_class
