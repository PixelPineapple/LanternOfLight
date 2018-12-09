/*---------------------------------------------------
 * 制作日 : 2018年09月26日
 * 制作者：シスワントレサ
 * 内容　：光の大きさや明るくさを管理するクラス
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour {

    // 光の明るくさ
    [SerializeField]
    private float lampIntensity = 0;
    // ライトゲームオブジェクトを参考する
    private Light thisLight;
    // ライトの大きさ
    private float lightRange;

    // 初期化
    void Awake()
    {
        thisLight = gameObject.GetComponent<Light>();
        lightRange = thisLight.range;
    }

    // GameEvent「TakingLantern」から呼び出されるメソッド
    public void Invoked()
    {
        thisLight.intensity = lampIntensity;
    }

    // 更新
    public void FixedUpdate()
    {
        thisLight.range = Random.Range(lightRange - 0.07f, lightRange + 0.07f);
    }
} // !_class
