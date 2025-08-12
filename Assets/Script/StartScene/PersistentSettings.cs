using UnityEngine;
using UnityEngine.UI;
using TMPro; // TMPro 네임스페이스 추가

public class PersistentSettings : MonoBehaviour
{
    private static PersistentSettings instance;

    public Slider soundSlider;
    public TMP_Dropdown windowModeDropdown; // TMP_Dropdown으로 변경

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

    private void Start()
    {
        LoadSettings();
        // UI 요소에 대한 이벤트 리스너 추가
        soundSlider.onValueChanged.AddListener(delegate { SaveSettings(); });
        windowModeDropdown.onValueChanged.AddListener(delegate { SaveSettings(); });
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("SoundVolume", soundSlider.value);
        PlayerPrefs.SetInt("WindowMode", windowModeDropdown.value);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1.0f);
        windowModeDropdown.value = PlayerPrefs.GetInt("WindowMode", 0);
    }
}
