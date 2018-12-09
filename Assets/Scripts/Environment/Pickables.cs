/*---------------------------------------------------
 * 制作日 : 2018年10月03日
 * 制作者：シスワントレサ
 * 内容　：アイテムを見つける時
 * 最後の更新：2018年11月10日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickables : MonoBehaviour
{
    // アイテムデータ
    public PickablesData pickablesData;
    // 獲得システムUI管理するクラス
    public AcquiredPanelSystem acquiredPanel;
    // 取った後、ゲームオブジェクトを削除する必要がある？
    public bool isDestroyOnPickUp;
    // アイテムを獲得のサウンド
    public AudioClip receivedClip;
    public AudioClip followUpClip;
    // アイテムを獲得後のスプライト画像 「isDestroyedOnPickUpがTrue場合は使わない」
    public Sprite itemPickedUpSprite;
    
    public void Invoked()
    {
        if (!pickablesData.isPicked)
        {
            pickablesData.isPicked = true;
            PreloadComponent.soundManager.PlayOnceEFX(receivedClip, followUpClip);
            if (acquiredPanel != null)
            {
                // pickablesDataを転送
                acquiredPanel.GetPickablesInfo(pickablesData);
            }
            // ゲームオブジェクトを破壊するべきですか？
            if (isDestroyOnPickUp) { Destroy(gameObject); }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = itemPickedUpSprite;
            }
        }
    }
} // !_class
