/*---------------------------------------------------
 * 制作日 : 2018年10月04日
 * 制作者：シスワントレサ
 * 内容　：対話情報を管理するクラス
 * 最後の更新：2018年10月4日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    #region 変数
    // 人間の顔の写真
    [SerializeField]
    private Image humanPortrait;
    public Image HumanPortrait
    {
        get { return humanPortrait; }
        set { humanPortrait = value; }
    }

    // 人間名
    [SerializeField]
    private new TMPro.TextMeshProUGUI name;
    public TMPro.TextMeshProUGUI Name
    {
        get { return name; }
        set { name = value; }
    }

    // 人間の対話
    [SerializeField]
    private TMPro.TextMeshProUGUI dialogue;
    public TMPro.TextMeshProUGUI Dialogue
    {
        get { return dialogue; }
        set { dialogue = value; }
    }

    // 犬が探している人間ですか？
    private bool isCorrectHuman;
    public bool IsCorrectHuman
    {
        get { return isCorrectHuman; }
        set { isCorrectHuman = value; }
    }

    // ダイアログキュー
    private Queue<string> dialogueQueue;

    /// <summary>
    /// 現在犬と話しているのか？
    /// </summary>
    private bool isTalking;
    public bool IsTalking
    {
        get { return isTalking; }
        set { isTalking = value; }
    }

    // ボタンを押すと、対話が進む
    [SerializeField]
    private GameObject pressToNext;

    // 考える時間
    [SerializeField]
    private float timeToThink = 2.0f;
    #endregion

    // 初期化
    private void Start()
    {
        dialogueQueue = new Queue<string>();
        isTalking = false;
    }

    // 対話が始まる
    public void StartConversation(string[] sentences)
    {
        // ダイアログキューを綺麗に
        dialogueQueue.Clear();

        // 全部の人間の対話がダイアログキューに入れる
        foreach (string sentence in sentences)
        {
            dialogueQueue.Enqueue(sentence);
        }
        // 対話が進む
        ContinueConversation();
    }

    // 対話が進む
    public void ContinueConversation()
    {
        // 次のボタンを無効にする
        pressToNext.SetActive(false);
        // 全部の対話が表示された場合
        if(dialogueQueue.Count == 0)
        {
            StopAllCoroutines();
            // 「人生の本質」を渡すか渡さないか
            GiveOrLeave();
            return;
        }
        // 次の対話を表示する
        string sentence = dialogueQueue.Dequeue();
        StopAllCoroutines();
        // 対話を表示
        StartCoroutine(TypeSentence(sentence));
    }

    // 対話を表示
    IEnumerator TypeSentence (string sentence)
    {
        dialogue.text = "";
        // 対話を一つずつ表示する
        StringBuilder builder = new StringBuilder();
        foreach (char letter in sentence.ToCharArray())
        {
            builder.Append(letter);
            dialogue.text = builder.ToString();
            yield return null;
        }
        // 次のボタンを画面に出す
        pressToNext.SetActive(true);
    }

    // 「人生の本質」を渡すか渡さないかのメソッド
    void GiveOrLeave()
    {
        dialogue.text = "人生の本質を" + name.text + "にあげようか?";
        // プレイヤ入力を待つ
        StartCoroutine(WaitForKeyPressed());
    }

    // 渡すか渡さないかを入力待ち
    IEnumerator WaitForKeyPressed()
    {
        yield return new WaitForSeconds(timeToThink);

        // 入力待ち
        bool keyPressed = false;
        while(!keyPressed)
        {
            // Debug.Log("Enter Loop");
            if (Input.GetKeyDown(KeyCode.X)) // プレイヤは話した人間を離れる
            {
                // Debug.Log("X Key Pressed !!!");
                EndConversation();
                yield break;
            }
            else if (Input.GetKeyUp(KeyCode.C)) // ライトを人間に渡す「ゲームオーバーかどうか」
            {
                // Debug.Log("C Key Pressed !!!");
                keyPressed = true;
            }
            yield return null;
        }
        // ゲーム終了、結果を報告する
        PreloadComponent.gameOver.Gameover(isCorrectHuman);

        yield break;
    }

    // 対話終了
    public void EndConversation()
    {
        StopAllCoroutines();
        // 対話UIを閉じる
        gameObject.GetComponent<Animator>().SetBool("IsTalking", false);
        isTalking = false;
        // プレイヤは入力が得られるように。
        PreloadComponent.events.playerIsControllable.Raise();
    }
} // !class
