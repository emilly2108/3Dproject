using UnityEngine;
using UnityEngine.SceneManagement; 
public class StartMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsUI; 
    public void LoadShow1Scene()
    {
        SceneManager.LoadScene("Show 1");
    }
    public void OpenSettingsUI()
    {
        settingsUI.SetActive(true);

    }
    public void CloseSettingsUI()
    {
        settingsUI.SetActive(false);

    }
}
