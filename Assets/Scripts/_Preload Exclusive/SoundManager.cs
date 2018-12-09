/*---------------------------------------------------
 * 制作日 : 2018年10月29日
 * 制作者：シスワントレサ
 * 内容　：サウンドを管理するクラス
 * 最後の更新：2018年10月29日
 * ----------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO : Optimization
public class SoundManager : MonoBehaviour {

    // オーディオソース
    public AudioSource musicSource;           // BGM
    public AudioSource efxSource;               // efx
    public AudioSource followUpEfxSource;
    public float lowPitchRange = .95f;          // 低ピッチ
    public float highPitchRange = 1.05f;       // ハイピッチ
    public float highVolume = 0.5f;              // 大音量
    
    // シングルサウンドクリップをプレイ
    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

    public void RandomizeSFX (params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);

        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxSource.pitch = randomPitch;

        efxSource.clip = clips[randomIndex];

        efxSource.Play();
    }
    
    // EFXを一回プレイする
    public void PlayOnceEFX(AudioClip firstClip, AudioClip secondClip = null)
    {
        // EFX音量を上がる
        efxSource.volume = highVolume;

        // 一番目のefxAudioを設定して、起動させる。
        efxSource.clip = firstClip;
        efxSource.Play();

        // 二番目のefxAudioがあれば、設定する
        if (secondClip != null)
        {
            // ファローアップサウンドがあれば
            followUpEfxSource.clip = secondClip;
            // 前回のサウンドが終わったとともに、スタート
            Invoke("PlayFollowUpClip", firstClip.length);
        }
        // EFX音量を下がる
        StartCoroutine(loweringSounds());
    }
    
    // 二番目のファローアップEFX
    private void PlayFollowUpClip()
    {
        followUpEfxSource.Play();
    }

    // サウンド音量を下がる
    // TODO : optimize
    IEnumerator loweringSounds()
    {
        yield return new WaitForSeconds(1.0f);
        PreloadComponent.soundManager.efxSource.volume = 0.4f;
        yield return new WaitForSeconds(1.0f);
        PreloadComponent.soundManager.efxSource.volume = 0.3f;
    }
} // !_class
