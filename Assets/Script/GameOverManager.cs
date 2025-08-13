using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    private void Start()
    {
        SoundManager.instance.PlayBGM("gameOverBGM");
    }
    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Show1Scene()
    {
        SceneManager.LoadScene("Show 1");
    }

}
