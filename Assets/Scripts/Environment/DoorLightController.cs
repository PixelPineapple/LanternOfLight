/*---------------------------------------------------
 * 制作日 : 2018年11月19日
 * 制作者：シスワントレサ
 * 内容　：ドアのライトを管理するクラス
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Light))]
public class DoorLightController : MonoBehaviour {

    // SpotLight
    private Light thisLight;
    // エベント後のSpot角度
    [SerializeField] private float desiredSpotAngle;
    [SerializeField] private float waitTime;

    // 初期化
    public void Start()
    {
        thisLight = gameObject.GetComponent<Light>();
    }

    // エベントをスタート
    public void StartEvent()
    {
        StartCoroutine(EnlargingSpotAngle());
    }

    // Spot角度を拡大
    IEnumerator EnlargingSpotAngle()
    {
        while (thisLight.spotAngle < desiredSpotAngle)
        {
            thisLight.spotAngle += 1;
            yield return new WaitForSeconds(waitTime);
        }
    }
} // !_class
