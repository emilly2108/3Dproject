using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingManager : MonoBehaviour
{
    public static SettingManager instance;

    [Header("UI References")]
    public Slider bgmSlider;
    public Slider seSlider;
    public TMP_Dropdown windowModeDropdown;

    public Slider brightnessSlider; 
    public UnityEngine.Rendering.Volume volume; 
    private UnityEngine.Rendering.Universal.ColorAdjustments colorAdjustments;
    private float defaultExposure = 0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        
        windowModeDropdown.ClearOptions();
        windowModeDropdown.AddOptions(new System.Collections.Generic.List<string>
        {
            "전체 화면",
            "창 모드",
            "전체 창"
        });

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

        if (brightnessSlider != null)
        {
            brightnessSlider.onValueChanged.AddListener(OnBrightnessChanged);
        }


        bgmSlider.onValueChanged.AddListener(OnBgmVolumeChanged);
        seSlider.onValueChanged.AddListener(OnSeVolumeChanged);
        windowModeDropdown.onValueChanged.AddListener(OnWindowModeChanged);
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

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("BGM_Volume", bgmSlider.value);
        PlayerPrefs.SetFloat("SE_Volume", seSlider.value);
        PlayerPrefs.SetInt("WindowMode", windowModeDropdown.value);
        PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);

        PlayerPrefs.Save();
        Debug.Log("환경설정 저장 완료");
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey("BGM_Volume"))
            bgmSlider.value = PlayerPrefs.GetFloat("BGM_Volume");
        else
            bgmSlider.value = 1f;

        if (PlayerPrefs.HasKey("SE_Volume"))
            seSlider.value = PlayerPrefs.GetFloat("SE_Volume");
        else
            seSlider.value = 1f;

        if (PlayerPrefs.HasKey("WindowMode"))
            windowModeDropdown.value = PlayerPrefs.GetInt("WindowMode");
        else
            windowModeDropdown.value = GetDropdownIndexFromScreenMode(Screen.fullScreenMode);

        if (PlayerPrefs.HasKey("Brightness"))
            brightnessSlider.value = PlayerPrefs.GetFloat("Brightness");
        else
            brightnessSlider.value = 0.5f;

    }
}
