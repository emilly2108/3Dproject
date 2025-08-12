using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{

    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Show1Scene()
    {
        SceneManager.LoadScene("Show 1");
    }

}
