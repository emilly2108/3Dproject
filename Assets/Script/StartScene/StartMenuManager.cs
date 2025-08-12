using UnityEngine;
using UnityEngine.SceneManagement; 
public class StartMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsUI;

    private void Start()
    {
        if (settingsUI != null)
            settingsUI.SetActive(false);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void LoadShow1Scene()
    {
        SceneManager.LoadScene("Show 1");
    }

    public void OpenSettingsUI()
    {
        if (settingsUI != null)
            settingsUI.SetActive(true);
    }

    public void CloseSettingsUI()
    {
        if (settingsUI != null)
            settingsUI.SetActive(false);
    }
}
