using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;

public class SettingManager : MonoBehaviour
{   //✅
    public static SettingManager Instance { get; private set; }

    [Header("음량")]
    public Slider bgmSlider;
    public Slider seSlider;

    [Header("디스플레이")]
    public TMP_Dropdown windowModeDropdown;
    public Slider brightnessSlider;

    [Header("밝기")]
    public Volume volume;
    private ColorAdjustments colorAdjustments;
    private float defaultExposure = 0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitDropdown();
        LoadSettings(); 

    
        if (SoundManager.instance != null)
        {
            SoundManager.instance.BGM_masterVolume = bgmSlider.value;
            SoundManager.instance.SE_masterVolume = seSlider.value;
        }


        OnWindowModeChanged(windowModeDropdown.value);

        if (volume != null && volume.profile.TryGet(out colorAdjustments))
        {
            defaultExposure = colorAdjustments.postExposure.value;
        }

        bgmSlider.onValueChanged.AddListener(OnBgmVolumeChanged);
        seSlider.onValueChanged.AddListener(OnSeVolumeChanged);
        brightnessSlider.onValueChanged.AddListener(OnBrightnessChanged);
        windowModeDropdown.onValueChanged.AddListener(OnWindowModeChanged);
    }

    private void InitDropdown()
    {
        windowModeDropdown.ClearOptions();
        windowModeDropdown.AddOptions(new List<string> { "전체 화면", "창 모드", "전체 창" });
    }

    private void OnBgmVolumeChanged(float value)
    {
        if (SoundManager.instance != null)
            SoundManager.instance.BGM_masterVolume = value;
    }

    private void OnSeVolumeChanged(float value)
    {
        if (SoundManager.instance != null)
            SoundManager.instance.SE_masterVolume = value;
    }

    private void OnWindowModeChanged(int index)
    {
        switch (index)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
        }
    }

    private int GetDropdownIndexFromScreenMode(FullScreenMode mode)
    {
        switch (mode)
        {
            case FullScreenMode.ExclusiveFullScreen: return 0;
            case FullScreenMode.Windowed: return 1;
            case FullScreenMode.FullScreenWindow: return 2;
            default: return 1;
        }
    }

    private void OnBrightnessChanged(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.postExposure.value = Mathf.Lerp(-2f, 2f, value);
        }
    }

    public static void SaveSettings()
    {
        if (Instance == null) return;

        PlayerPrefs.SetFloat("BGM_Volume", Instance.bgmSlider.value);
        PlayerPrefs.SetFloat("SE_Volume", Instance.seSlider.value);
        PlayerPrefs.SetInt("WindowMode", Instance.windowModeDropdown.value);
        PlayerPrefs.SetFloat("Brightness", Instance.brightnessSlider.value);

        PlayerPrefs.Save();
        Debug.Log("환경설정 저장 완료");
    }

    public static void LoadSettings()
    {
        if (Instance == null) return;

        if (PlayerPrefs.HasKey("BGM_Volume"))
            Instance.bgmSlider.value = PlayerPrefs.GetFloat("BGM_Volume");
        else
            Instance.bgmSlider.value = 1f;
        Instance.OnBgmVolumeChanged(Instance.bgmSlider.value);

        if (PlayerPrefs.HasKey("SE_Volume"))
            Instance.seSlider.value = PlayerPrefs.GetFloat("SE_Volume");
        else
            Instance.seSlider.value = 1f;
        Instance.OnSeVolumeChanged(Instance.seSlider.value); 

        if (PlayerPrefs.HasKey("WindowMode"))
            Instance.windowModeDropdown.value = PlayerPrefs.GetInt("WindowMode");
        else
            Instance.windowModeDropdown.value = Instance.GetDropdownIndexFromScreenMode(Screen.fullScreenMode);
        Instance.OnWindowModeChanged(Instance.windowModeDropdown.value);

        if (PlayerPrefs.HasKey("Brightness"))
            Instance.brightnessSlider.value = PlayerPrefs.GetFloat("Brightness");
        else
            Instance.brightnessSlider.value = 0.5f;
        Instance.OnBrightnessChanged(Instance.brightnessSlider.value); 
    }

}
