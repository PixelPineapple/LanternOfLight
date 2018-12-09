/*---------------------------------------------------
 * 制作日 : 2018年10月04日
 * 制作者：シスワントレサ
 * 内容　：人間が持ち込まれた情報
 * 最後の更新：2018年10月04日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanData : MonoBehaviour {

    // 人間のテンプレートデータ
    public HumanTemplate data;

    // ダイアログパネルUI
    [SerializeField]
    private GameObject dialoguePanel;

    // 対話している中の人間のデータがダイアログUIに渡す
    public void CurrentlyInteracting()
    {
        dialoguePanel.GetComponent<DialogueManager>().IsTalking = true;
        dialoguePanel.GetComponent<DialogueManager>().Name.text = data.name;
        dialoguePanel.GetComponent<DialogueManager>().HumanPortrait.sprite = data.portrait;
        dialoguePanel.GetComponent<DialogueManager>().IsCorrectHuman = data.isCorrect;
        // パネルを呼び出す。
        dialoguePanel.GetComponent<Animator>().SetBool("IsTalking", true);
        dialoguePanel.GetComponent<DialogueManager>().StartConversation(data.sentences);
        // Set to false to prevent wrong display in the GUI
        gameObject.GetComponent<GameEventListener>().enabled = false;
    }
}   // !_class
