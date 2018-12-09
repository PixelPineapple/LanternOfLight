/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：当たり判定を管理するクラス
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class RaycastController : MonoBehaviour {

    public LayerMask collisionMask;
    const float dstBetweenRays = .1f; // キャラーの大きさ次第、いくつの光線が必要なのかを自動で判断できるように。

    [HideInInspector]
    public float horizontalRaySpacing; // 水平に発射した光線の間隔
    [HideInInspector]
    public float verticalRaySpacing; // 垂直に発射した光線の間隔 
    [HideInInspector]
    public float horizontalRayCount; // 水平に発射する光線の数
    [HideInInspector]
    public float verticalRayCount; // 垂直に発射した光線の数 

    [HideInInspector]
    public BoxCollider2D boxCollider;
    public RayCastOrigin rayCastOrigins;

    public const float skinWidth = .015f; // コライダーの外側からではなく、少し内側からそとに光線を発射
    
    void Awake () {
        boxCollider = GetComponent<BoxCollider2D>();
	}
	
    public virtual void Start()
    {
        CalculateRaySpacing();
    }

    /// <summary>
    /// Raycastのポイントを作る
    /// </summary>
    public void UpdateRayCastOrigins()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2); // 少し内側からそとに光線を発射
        rayCastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        rayCastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        rayCastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        rayCastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    /// <summary>
    /// キャラクタの体から出た光線を計算
    /// </summary>
    public void CalculateRaySpacing()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2); // 少し内側からそとに光線を発射

        float boundsWidth = bounds.size.x;
        float boundsHeight = bounds.size.y;

        horizontalRayCount = Mathf.RoundToInt(boundsHeight / dstBetweenRays);
        verticalRayCount = Mathf.RoundToInt(boundsWidth / dstBetweenRays);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    /// <summary>
    /// 光線の原点
    /// </summary>
    public struct RayCastOrigin
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }

} // !_class
