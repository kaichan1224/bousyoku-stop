using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音の管理を行うシングルトンクラス
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //AudioSource
    [SerializeField] private AudioSource bgmAudio;
    [SerializeField] private AudioSource SEAudio;
    //データ
    [SerializeField] private SoundMasterData soundMasterData;
    public void PlayBGM(SoundMasterData.SoundName soundName)
    {
        bgmAudio.clip = soundMasterData.GetSound(soundName);
        bgmAudio.Play();
    }

    public void StopBGM()
    {
        bgmAudio.Stop();
    }

    public void PlaySE(SoundMasterData.SoundName soundName)
    {
        SEAudio.PlayOneShot(soundMasterData.GetSound(soundName));
    }

    public void SetBGMVolume(float value)
    {
        // 音楽の音量をスライドバーの値に変更
        bgmAudio.volume = value;
    }

    public void SetSEVolume(float value)
    {
        // 音楽の音量をスライドバーの値に変更
        SEAudio.volume = value;
    }
}