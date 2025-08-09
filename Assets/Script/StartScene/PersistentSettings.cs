using UnityEngine;
using UnityEngine.UI;
using TMPro; // TMPro ���ӽ����̽� �߰�

public class PersistentSettings : MonoBehaviour
{
    private static PersistentSettings instance;

    public Slider soundSlider;
    public TMP_Dropdown windowModeDropdown; // TMP_Dropdown���� ����

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
        // UI ��ҿ� ���� �̺�Ʈ ������ �߰�
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
