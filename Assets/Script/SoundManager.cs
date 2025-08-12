using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    #region singleton
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    #endregion singleton

    public AudioSource audioSourceBgm;
    public AudioSource[] audioSourceEffects;

    public string[] playSoundName;

    public Sound[] effectSounds;
    public Sound[] bgmSounds;

    [SerializeField, Range(0f, 1f)]
    private float bgmMasterVolume = 1f; // 기본 100%
    [SerializeField, Range(0f, 1f)]
    private float seMasterVolume = 1f;  // 기본 100%

    public float BGM_masterVolume
    {
        get => bgmMasterVolume;
        set
        {
            bgmMasterVolume = Mathf.Clamp01(value);
            ApplyBGMVolume();
        }
    }

    public float SE_masterVolume
    {
        get => seMasterVolume;
        set
        {
            seMasterVolume = Mathf.Clamp01(value);
            ApplySEVolume();
        }
    }

    void Start()
    {
        playSoundName = new string[audioSourceEffects.Length];
        ApplyBGMVolume();
        ApplySEVolume();
    }

    private void ApplyBGMVolume()
    {
        if (audioSourceBgm != null)
            audioSourceBgm.volume = 1f * bgmMasterVolume;
    }

    private void ApplySEVolume()
    {
        foreach (var se in audioSourceEffects)
        {
            if (se != null)
                se.volume = 1f * seMasterVolume;
        }
    }

    public void PlaySE(string _name)
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if (_name == effectSounds[i].name)
            {
                for (int j = 0; j < audioSourceEffects.Length; j++)
                {
                    if (!audioSourceEffects[j].isPlaying)
                    {
                        playSoundName[j] = effectSounds[i].name;
                        audioSourceEffects[j].clip = effectSounds[i].clip;
                        audioSourceEffects[j].Play();
                        return;
                    }
                }
                Debug.Log("모든 가용 AudioSource 사용중");
                return;
            }
        }
        Debug.Log(_name + " 사운드가 SoundManager에 등록안됨");
    }

    public void StopAllSE()
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            audioSourceEffects[i].Stop();
        }
    }

    public void StopSE(string _name)
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            if (playSoundName[i] == _name)
            {
                audioSourceEffects[i].Stop();
                return;
            }
        }
        Debug.Log("재생 중인 " + _name + " 사운드가 없습니다");
    }

    public void PlayBGM(string _name, bool loop = true)
    {
        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if (bgmSounds[i].name == _name)
            {
                if (audioSourceBgm.clip == bgmSounds[i].clip && audioSourceBgm.isPlaying)
                    return;

                audioSourceBgm.clip = bgmSounds[i].clip;
                audioSourceBgm.loop = loop;
                audioSourceBgm.Play();
                ApplyBGMVolume();
                return;
            }
        }
        Debug.LogWarning(_name + " BGM이 SoundManager에 등록되어 있지 않습니다.");
    }

    public void StopBGM()
    {
        if (audioSourceBgm.isPlaying)
            audioSourceBgm.Stop();
    }

    public void PauseBGM()
    {
        if (audioSourceBgm.isPlaying)
            audioSourceBgm.Pause();
    }

    public void ResumeBGM()
    {
        if (audioSourceBgm.clip != null && !audioSourceBgm.isPlaying)
            audioSourceBgm.Play();
    }
}
