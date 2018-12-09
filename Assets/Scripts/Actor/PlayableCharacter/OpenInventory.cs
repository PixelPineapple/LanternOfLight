/*---------------------------------------------------
 * 制作日 : 2018年10月15日
 * 制作者：シスワントレサ
 * 内容　：インベントリパネルを開く
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Player))]
public class OpenInventory : MonoBehaviour
{
    // インベントリーパネル
    [SerializeField]
    private GameObject inventoryPanel;
    // インベントリーを開いてる中
    private bool isOpen;
    // ボタンを押したら、インベントリーが開ける
    [SerializeField]
    private KeyCode buttonToOpen;
    // インベントリーの更新エベント
    public GameEvent updateInventory;
    // イメージを更新するクラス
    [SerializeField]
    private UpdateImage updateImage;
    // ボタンを押すと、インベントリーを開く
    [SerializeField]
    private ButtonAPressed buttonAPressed;
    
    // 初期化
    private void Start()
    {
        isOpen = false;
    }

    // 更新
    void Update () {
        if (inventoryPanel != null && Input.GetKeyDown(buttonToOpen))
        {
            if (gameObject.GetComponent<Player>().PCondition == Player.PlayerCondition.CONTROLLABLE && !isOpen) // インベントリが開いていない
            {
                // インベントリを開く
                isOpen = true;
                // プレイヤの動きを止める
                PreloadComponent.events.playerisOpeningInventory.Raise();
            }
            else if (gameObject.GetComponent<Player>().PCondition == Player.PlayerCondition.LOOKINVENTORY && isOpen) // インベントリが開いている
            {
                // インベントリを閉める
                isOpen = false;
                // キャラの動きを持続する
                PreloadComponent.events.playerIsControllable.Raise();
            }
            updateImage.ChangeImage(isOpen); // 鞄の画像を更新する
            buttonAPressed.CurrentlyOpened(isOpen); // A-ボタンの画像を更新する
            inventoryPanel.SetActive(isOpen);
            updateInventory.Raise();
        }
	}
}   // !_class
