/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：プレイヤを追いかけるカメラ
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public CharacterController2D target; // カメラのターゲット
    public float verticalOffset;
    public float lookAheadDstX;
    public float lookSmoothTimeX;
    public float verticalSmoothTime;
    public Vector2 focusAreaSize;

    FocusArea focusArea;

    float currentLookAheadX;
    float targetLookAheadX;
    float lookAheadDirX;
    float smoothLookVelocityX;
    float smoothVelocityY;

    bool lookAheadStopped;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        focusArea = new FocusArea(target.boxCollider.bounds, focusAreaSize);
    }

    /// <summary>
    /// All code written inside LateUpdate are to be executed at the last time before moving onto a new frame.
    /// Usually used for Camera update.
    /// </summary>
    private void LateUpdate()
    {
        // フォーカスエリアを更新する
        focusArea.Update(target.boxCollider.bounds);

        // カメラがフォーカスエリアを追いかける
        Vector2 focusPosition = focusArea.center + Vector2.up * verticalOffset;

        if (focusArea.velocity.x != 0)
        {
            lookAheadDirX = Mathf.Sign(focusArea.velocity.x);
            if (Mathf.Sign(target.playerInput.x) == Mathf.Sign(focusArea.velocity.x) && target.playerInput.x != 0)
            {
                lookAheadStopped = false;
                targetLookAheadX = lookAheadDirX * lookAheadDstX;
            }
            else
            {
                if (!lookAheadStopped)
                {
                    lookAheadStopped = true;
                    targetLookAheadX = currentLookAheadX + (lookAheadDirX * lookAheadDstX - currentLookAheadX) / 4f;
                }
            }
        }
        // スムーズにX-軸にカメラを動かせる
        currentLookAheadX = Mathf.SmoothDamp(currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookSmoothTimeX);
        // スムーズにY-軸にカメラを動かせる
        focusPosition.y = Mathf.SmoothDamp(transform.position.y, focusPosition.y, ref smoothVelocityY, verticalSmoothTime);
        focusPosition += Vector2.right * currentLookAheadX;
        // カメラを動かせる
        transform.position = (Vector3)focusPosition + Vector3.forward * -10;
    }

    /// <summary>
    /// フォーカスエリアのビジュアルデバッグを描画
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(focusArea.center, focusAreaSize);
    }

    /// <summary>
    /// ターゲットの周りの注目されるところ「フォーカスエリア」
    /// </summary>
    struct FocusArea
    {
        public Vector2 center;
        public Vector2 velocity; // 最後のフレームでフォーカスエリアがどれだけ移動したかを検査
        float left, right;
        float top, bottom;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="targetBounds">プレイヤから取った長方形のコライダー</param>
        /// <param name="size">注目されるところのサイズ</param>
        public FocusArea(Bounds targetBounds, Vector2 size)
        {
            left = targetBounds.center.x - size.x / 2;
            right = targetBounds.center.x + size.x / 2;
            bottom = targetBounds.min.y;
            top = targetBounds.min.y + size.y;

            velocity = Vector2.zero;
            center = new Vector2((left + right) / 2, (top + bottom) / 2);
        }

        /// <summary>
        /// ターゲットとともにフォーカスエリアを移動させる
        /// </summary>
        /// <param name="targetBounds"></param>
        public void Update(Bounds targetBounds)
        {
            #region X-軸に移動
            float shiftX = 0;
            if (targetBounds.min.x < left)
            {
                shiftX = targetBounds.min.x - left;
            }
            else if (targetBounds.max.x > right)
            {
                shiftX = targetBounds.max.x - right;
            }
            left += shiftX;
            right += shiftX;
            #endregion

            #region Y-軸に移動
            float shiftY = 0;
            if (targetBounds.min.y < bottom)
            {
                shiftY = targetBounds.min.y - bottom;
            }
            else if (targetBounds.max.y > top)
            {
                shiftY = targetBounds.max.y - top;
            }
            top += shiftY;
            bottom += shiftY;
            #endregion

            // フォーカスエリアの中心位置を更新する
            center = new Vector2((left + right) / 2, (top + bottom) / 2);
            velocity = new Vector2(shiftX, shiftY);
        }
    }
}
