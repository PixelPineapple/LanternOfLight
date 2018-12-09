/*---------------------------------------------------
 * 制作日 : 2018年11月09日
 * 制作者：シスワントレサ
 * 内容　：アイテムを選択する時、名前と説明を表示する
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSelected : MonoBehaviour, ISelectHandler {

    [SerializeField]
    private TMP_Text itemName;
    [SerializeField]
    private TMP_Text itemDesc;
    private PickablesData inventoryData;

    void Start()
    {
        inventoryData = GetComponent<UpdateInventoryData>().pickableData;
    }
    
    public void OnSelect(BaseEventData eventData)
    {
        if (inventoryData.isPicked)
        {
            itemName.text = inventoryData.kanjiName;
            itemDesc.text = inventoryData.description;
        }
    }
}
