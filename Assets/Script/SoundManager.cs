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
    static public SoundManager instance;
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

    void Start()
    {
        playSoundName = new string[audioSourceEffects.Length];
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
                Debug.Log("��� ���� AudioSource�����");
                return;
            }
        }
        Debug.Log(_name + "���尡 SoundManager�� ��Ͼȵ�");
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
                break;
            }
        }
        Debug.Log("��� ����" + _name + "���尡 �����ϴ�");
    }
    // BGM ��� (�̸����� ã�Ƽ� ���)
    public void PlayBGM(string _name, bool loop = true)
    {
        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if (bgmSounds[i].name == _name)
            {
                if (audioSourceBgm.clip == bgmSounds[i].clip && audioSourceBgm.isPlaying)
                {
                    // �̹� ���� BGM�� ������̸� �׳� ����
                    return;
                }
                audioSourceBgm.clip = bgmSounds[i].clip;
                audioSourceBgm.loop = loop;
                audioSourceBgm.Play();
                return;
            }
        }
        Debug.LogWarning(_name + " BGM�� SoundManager�� ��ϵǾ� ���� �ʽ��ϴ�.");
    }

    // BGM ����
    public void StopBGM()
    {
        if (audioSourceBgm.isPlaying)
            audioSourceBgm.Stop();
    }

    // BGM �Ͻ�����
    public void PauseBGM()
    {
        if (audioSourceBgm.isPlaying)
            audioSourceBgm.Pause();
    }

    // BGM �ٽ� ��� (�Ͻ����� ��)
    public void ResumeBGM()
    {
        if (audioSourceBgm.clip != null && !audioSourceBgm.isPlaying)
            audioSourceBgm.Play();
    }
}


