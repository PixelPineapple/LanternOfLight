/*---------------------------------------------------
 * 制作日 : 2018年09月30日
 * 制作者：シスワントレサ
 * 内容　：ランタンを獲得すると、プレイヤにある光オブジェクトをオンにする
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Light))]
public class SwitchONLantern : MonoBehaviour {
    
    private new Light light;

    // 初期化
    private void Awake()
    {
        light = GetComponent<Light>();
    }

    // スイッチオン
    public void SwitchOn()
    {
        // エラー管理：ライトがNullの場合
        if (light == null)
        {
            light = GetComponent<Light>();
        }
        
        // ライトをオンにする
        if (!light.isActiveAndEnabled)
        {
            light.enabled = true;
        }
    }
} // !_class
