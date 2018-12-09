/*---------------------------------------------------
 * 制作日 : 2018年10月18日
 * 制作者：シスワントレサ
 * 内容　：インベントリ鞄の画像を更新する
 * 最後の更新：2018年10月18日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Image))]
public class UpdateImage : MonoBehaviour {
    
    private Image image;            // イメージコンポネント
    [SerializeField]
    private Sprite openImage;     // インベントリーが開いている
    [SerializeField]
    private Sprite closedImage;   // インベントリーが閉じられている

    // 初期化
    private void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    // インベントリーが開いているか閉じられているかに基づいて、鞄の画像を変更
    public void ChangeImage(bool isOpen)
    {
        if (isOpen)
            image.sprite = openImage;
        else
            image.sprite = closedImage;
    }
}
