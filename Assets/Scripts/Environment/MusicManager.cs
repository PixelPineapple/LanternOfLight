/*---------------------------------------------------
 * 制作日 : 2018年11月10日
 * 制作者：シスワントレサ
 * 内容　：場所に基づいてBGMを再生する
 * 最後の更新：2018年11月10日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class MusicManager : MonoBehaviour {

    // BGMファイル
    public AudioClip gameBGM;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" &&
            PreloadComponent.soundManager.musicSource.clip != gameBGM)
        {
            // BGMをプレイ
            Debug.Log("Entering Musicmanager");
            PreloadComponent.soundManager.musicSource.clip = gameBGM;
            PreloadComponent.soundManager.musicSource.Play();
        }
    }

} // !_class
