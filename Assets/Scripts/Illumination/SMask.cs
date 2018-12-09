/*---------------------------------------------------
 * 制作日 : 2018年11月10日
 * 制作者：シスワントレサ
 * 内容　：スプライトマスクのエフェクトを管理するクラス
 * 最後の更新：2018年11月12日
 * 
 * !!!! もう使わない !!!!
 * 
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMask : MonoBehaviour {

    [Range(0.05f, 0.2f)]
    public float flickTime;

    [Range(0.02f, 0.09f)]
    public float addSize;

    float timer = 0;
    private bool isGoingBigger = true;

    public Transform target;

    // 更新
	void Update () {
        timer += Time.deltaTime;
        
        // フリッカー「ランダムで大きく小さくにする」
        if (timer > flickTime)
        {
            if (isGoingBigger)
                transform.localScale = new Vector3(transform.localScale.x + addSize,
                    transform.localScale.y + addSize,
                    transform.localScale.z);
            else
                transform.localScale = new Vector3(transform.localScale.x - addSize,
                    transform.localScale.y - addSize,
                    transform.localScale.z);

            timer = 0;
            isGoingBigger = !isGoingBigger;
        }

        if (target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.position, 20 * Time.deltaTime);
	}
}
